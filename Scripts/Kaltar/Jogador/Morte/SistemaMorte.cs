﻿/*
 * Autor: Tiago Augusto Data: 26/2/2005 
 * Projeto: Kaltar
 */
 
using System;
using Server;
using Server.Mobiles;
using System.Collections.Generic;
using Server.ACC.CM;
using Kaltar.Classes;
using Server.Commands;

namespace Kaltar.Morte
{
	/// <summary>
	/// Description of SistemaMorte.
	/// </summary>
    public class SistemaMorte	{

        public static void Initialize()
        {
               // Register our event handler
            EventSink.PlayerDeath += new PlayerDeathEventHandler(EventSink_PlayerDeath);

            CommandSystem.Register("testeMorte", AccessLevel.Player, new CommandEventHandler(testeMorte_OnCommand));
        }

        private static void testeMorte_OnCommand(CommandEventArgs e)
        {
            Jogador jogador = (Jogador)e.Mobile;

            jogador.SendMessage(jogador.getSistemaMorte() + "");
            jogador.SendMessage(jogador.getSistemaMorte() != null ? jogador.getSistemaMorte().getMorteModule() +"": null);

            //int d = jogador.getSistemaMorte().getMorteModule().Desmaio;
            int d = 1;

            jogador.SendMessage("Voce ja desmaiou {0} vezes", d);
        }

        //local da sala da morte.
        private static Point3D localSalaDaMorte = new Point3D(705, 818, -90);

        //número máximo de desmaio até ganhar um ponto de morte.
        private static int MaxDesmaio = 5;

        //número de minuto para ficar desmaiado
        private static int tempoDesmaio = 1;

        private static void EventSink_PlayerDeath(PlayerDeathEventArgs args)
        {
            Jogador jogador = (Jogador)args.Mobile;
            MorteModule mm = jogador.getSistemaMorte().getMorteModule();

            //mensagem
            jogador.SendMessage("voce acaba de desmaiar as {0}.", DateTime.Now);
            jogador.SendAsciiMessage("{0} acaba de desmaiar.", jogador.Name);

            if (mm != null)
            {
                //marca início de desmaio
                mm.Desmaiado = true;
                mm.InicioDesmaio = DateTime.Now;

                //manda o jogador para a sala da morte
                jogador.getSistemaMorte().teleportarSalaDaMorte();

                //inicia o timer de morte
                int tempoDesmaiado = (mm.Desmaio * TempoDesmaio) + 1; // para cada ponto de desmaio, fica mais tempo desmaiado
                mm.TimerMorte = new TimerMorte(jogador, tempoDesmaiado);
                mm.TimerMorte.Start();
            }
            else
            {
                Console.WriteLine("{0} não possui o modulo de morte.", jogador.Name);
            }
        }

        /**
         * Envia o jogador para a sala da morte.
         */
        private void teleportarSalaDaMorte()
        {
            jogador.MoveToWorld(localSalaDaMorte, Map.Malas);
        }

        /**
        * Envia o jogador para o local onde deve ser revivido.
        */
        private void teleportarLocalDeVolta()
        {
            //se tiver corpo, vai para o lugar do corpo
            if (jogador.Corpse != null)
            {
                jogador.MoveToWorld(jogador.Corpse.Location, jogador.Corpse.Map);
            }
            else
            {
                //se nao tiver corpo, vai para o lugar marcado
                MorteModule mm = jogador.getSistemaMorte().getMorteModule();
                object[] resultado = getLocalizacao(mm.LocalMaracado);

                jogador.MoveToWorld((Point3D)resultado[0], (Map)resultado[1]);
            }
        }

        private object[] getLocalizacao(string nomeLocal)
        {
            object[] local = new object[2];
            if (nomeLocal == "padrao")
            {
                local[0] = new Point3D(714, 819, -90);
                local[1] = Map.Malas;
            }
            else if (nomeLocal == "ouroBranco")
            {
                local[0] = new Point3D(714, 819, -90);
                local[1] = Map.Malas;
            }
            else if (nomeLocal == "loboLeite")
            {
                local[0] = new Point3D(714, 819, -90);
                local[1] = Map.Malas;
            }
            else
            {
                local[0] = new Point3D(0,0,0);
                local[1] = Map.Malas;
            }

            return local;
        }

        public void onTimerMorte()
        {
            MorteModule mm = jogador.getSistemaMorte().getMorteModule();

            //soma o desmaio
            mm.Desmaio++;

            if (mm.Desmaio > MaxDesmaio)
            {
                morreu();
            }
            else
            {
                voltarAVida();
            }
        }

        private void morreu()
        {
            MorteModule mm = jogador.getSistemaMorte().getMorteModule();

            mm.Morto = true;
            mm.Morte++;
            mm.InicioMorte = DateTime.Now;

            mm.Desmaio = MaxDesmaio;

            jogador.SendMessage("Voce acaba de morrer. Seu ponto de morte é {0}", mm.Morte);
        }

        private void voltarAVida()
        {
            MorteModule mm = jogador.getSistemaMorte().getMorteModule();

            mm.Desmaiado = false;
            mm.InicioDesmaio = DateTime.MinValue;
                
            teleportarLocalDeVolta();
                
            //reviver o jogador
            jogador.Resurrect();

            ajustarVidaManaStamina();

            jogador.SendMessage("Voce acaba de acordar. Seu ponto de desmaio é {0}", mm.Desmaio);
        }
           
        /**
         * Quando o jogador volta a vida, ajustar os pontos de vida, mana e stamina
         */ 
        private void ajustarVidaManaStamina()
        {
            jogador.Hits = (int)(jogador.HitsMax * 0.10);
            jogador.Stam = (int)(jogador.StamMax * 0.10);
            jogador.Mana = (int)(jogador.ManaMax * 0.10);
        }

        #region atributos

        //jogador dono dos talentos
        private Jogador jogador = null;

        #endregion

        #region propriedade

        public static int TempoDesmaio { get { return tempoDesmaio; } }

        #endregion

        public SistemaMorte(Jogador jogador){
            this.jogador = jogador;
        }

        /**
         * Recupera o modulo de talento
         */
        private MorteModule getMorteModule()
        {
            MorteModule tm = (MorteModule)CentralMemory.GetModule(jogador.Serial, typeof(MorteModule));
            return tm;
        }
    }

    #region timer de morte

    public class TimerMorte : Timer {

        Jogador jogador;

        public TimerMorte(Jogador jogador, int tempoDesmaiado) : base(TimeSpan.FromMinutes(tempoDesmaiado))
        {
            this.jogador = jogador;
        }

        protected override void OnTick()
        { 
            Console.WriteLine("{0} não foi tratado a tempo.", jogador.Name);

            jogador.getSistemaMorte().onTimerMorte();
        }
    }

    #endregion
}
