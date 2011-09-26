
//////////////////////////////////////////////////////////////////////
// Automatically generated by Bradley's GumpStudio and roadmaster's 
// RunUo_Exporter.dll,  Special thanks goes to Daegon whose work the 
// exporter was based off of, and Shadow wolf for his Template Idea.
//////////////////////////////////////////////////////////////////////
#define RunUo2_0

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Mobiles;
using Kaltar.Classes;

namespace Server.Kaltar.Gumps
{
    public class InclinacaoInicialGump : Gump
    {
        Jogador jogador;

        public InclinacaoInicialGump(Jogador jogador) : base( 20, 20 )
        {
            this.jogador = jogador;

            this.Closable=false;
			this.Disposable=false;
			this.Dragable=true;
            this.Resizable = false;

            AddPage(0);

            AddPage(1);
			AddBackground(77, 58, 515, 328, 9380);
			AddLabel(173, 102, 0, @"Inclinação");
			AddImage(109, 99, 52);
			AddLabel(156, 184, 0, @"Combate");
			AddLabel(155, 226, 0, @"Feitiçaria");
			AddLabel(155, 269, 0, @"Subterfugio");
            AddLabel(154, 310, 0, @"Espiritualista");
			AddButton(120, 188, 1209, 1210, (int)Buttons.pgCombatente, GumpButtonType.Page, 2);
            AddButton(120, 231, 1209, 1210, (int)Buttons.pdFeiticaria, GumpButtonType.Page, 3);
            AddButton(120, 274, 1209, 1210, (int)Buttons.pgSubterfugio, GumpButtonType.Page, 4);
            AddButton(120, 316, 1209, 1210, (int)Buttons.pgClericato, GumpButtonType.Page, 5);
			AddHtml( 279, 187, 280, 142, @"Selecione uma inclinação para saber dos detalhes.", (bool)true, (bool)true);

            string desCombate = "O personagem tem tendências para o combate armado, corpo-a-corpo, então possui habilidades nessa área, para que posteriormente continue sua especialização e melhore dentro de sua área. Personagens com essa inclinação são Guerreiros, Bárbaros, Arqueiros, Esgrimistas." +
                "<br/><br/><strong>Perícias</strong><br/><br/>" +
                "Swordmanship  " + "<br/>" +
                "Macefigthing  " + "<br/>" +
                "Fencing       " + "<br/>" +
                "Axe           " + "<br/>" +
                "Wrestling     " + "<br/>" +
                "Archery       " + "<br/>" +
                "Tactics       " + "<br/>" +
                "Parrying      ";

            AddPage(2);
			AddBackground(77, 58, 639, 509, 9380);
			AddImage(109, 99, 52);
			AddLabel(173, 102, 0, @"Inclinação");
            AddHtml(112, 173, 562, 311, desCombate, (bool)true, (bool)true);
            AddLabel(362, 123, 0, @"Combate");
			AddButton(603, 505, 247, 248, (int)Buttons.okCombate, GumpButtonType.Reply, 0);
			AddButton(522, 505, 241, 242, (int)Buttons.pgInicial, GumpButtonType.Page, 1);

            string desFeiticaria = "Com essa inclinação o personagem tem seu lado mistico mais desenvolvido, possuindo facilidade para magias. Personagens com essa inclinação são Magos, Necromancers, Feitiçeiros, Arquimagos, Bruxos." +
            "<br/><br/><strong>Perícias</strong><br/><br/>" +
                "Magery         " + "<br/>" +
                "Meditation     " + "<br/>" +
                "MagicResist    " + "<br/>" +
                "Inscribe       " + "<br/>" +
                "Macefigthing   ";

            AddPage(3);
			AddBackground(77, 58, 639, 509, 9380);
			AddImage(109, 99, 52);
			AddLabel(173, 102, 0, @"Inclinação");
            AddHtml(112, 173, 562, 311, desFeiticaria, (bool)true, (bool)true);
			AddLabel(362, 123, 0, @"Feitiçaria");
			AddButton(603, 505, 247, 248, (int)Buttons.okFeiticaria, GumpButtonType.Reply, 0);
            AddButton(522, 505, 241, 242, (int)Buttons.pgInicial, GumpButtonType.Page, 1);

            string desSubterfugio = "Alguns não são bons suficiente para o combate, nem nascem com dom para a magia ou uma espiritualidade elevada, porém, todos tem de ganhar a vida. Personagens com essa inclinação tendem a ser mais ágeis, espertos, bons de papo e com várias outras habilidades, sendo elas lícitas ou ilícitas. São alguns exemplos Gatunos, Bardos, Assassinos." +
                "<br/><br/><strong>Perícias</strong><br/><br/>" +
                "Fencing          " + "<br/>" +
                "Archery          " + "<br/>" +
                "Wrestling        " + "<br/>" +
                "Tactics          " + "<br/>" +
                "DetectHidden     " + "<br/>" +
                "Hiding           " + "<br/>" +
                "RemoveTrap       " + "<br/>" +
                "Lockpicking      " + "<br/>" +
                "Stealing         " + "<br/>" +
                "Stealth          ";

            AddPage(4);
			AddBackground(77, 58, 639, 509, 9380);
			AddImage(109, 99, 52);
			AddLabel(173, 102, 0, @"Inclinação");
            AddHtml(112, 173, 562, 311, desSubterfugio, (bool)true, (bool)true);
			AddLabel(362, 123, 0, @"Subterfugio");
			AddButton(603, 505, 247, 248, (int)Buttons.okSubterfugio, GumpButtonType.Reply, 0);
            AddButton(522, 505, 241, 242, (int)Buttons.pgInicial, GumpButtonType.Page, 1);

            string desEspiritualista = "Pessoas com a espiritualidade elevada, possuem essa inclinação, elas acreditam que algo superior a elas e tudo no mundo têm um propósito maior. Personagens com essa inclinação são, Clérigos, Druidas, Seminaristas." +
                "<br/><br/><strong>Perícias</strong><br/><br/>" +
                "Meditation      " + "<br/>" +
                "Macefigthing   " + "<br/>" +
                "Tactics          " + "<br/>" +
                "Healing          " + "<br/>" +
                "Veterinary      " + "<br/>" +
                "SpiritSpeak     " + "<br/>" +
                "Parrying         ";

            AddPage(5);
			AddBackground(77, 58, 639, 509, 9380);
			AddImage(109, 99, 52);
			AddLabel(173, 102, 0, @"Inclinação");
            AddHtml(112, 173, 562, 311, desEspiritualista, (bool)true, (bool)true);
			AddLabel(362, 123, 0, @"Espiritualista");
			AddButton(603, 505, 247, 248, (int)Buttons.okClericato, GumpButtonType.Reply, 0);
            AddButton(522, 505, 241, 242, (int)Buttons.pgInicial, GumpButtonType.Page, 1);
			
        }

        public enum Buttons
		{
			pgCombatente,
			pdFeiticaria,
			pgSubterfugio,
			pgClericato,
            pgInicial,
            okCombate,
			okFeiticaria,
			okSubterfugio,
			okClericato
		}


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
            
            switch(info.ButtonID)
            {
                case (int)Buttons.okCombate:
				{
                    Inclinacao.combate(jogador);
					break;
				}
                case (int)Buttons.okFeiticaria:
				{
                    Inclinacao.feiticaria(jogador);
					break;
				}
                case (int)Buttons.okSubterfugio:
				{
                    Inclinacao.subterfugio(jogador);
					break;
				}
                case (int)Buttons.okClericato:
				{
                    Inclinacao.clericato(jogador);
					break;
				}
            }

            jogador.SendMessage("A inclinação foi selecionada.");
        }
    }
}