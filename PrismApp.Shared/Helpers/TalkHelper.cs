using System;
using System.Collections.Generic;
using PrismApp.Domain;

namespace PrismApp.Shared
{
	public static class TalkHelper
	{
		public static List<Talk> GetTalks => new List<Talk>
			{
				new Talk(
					 "Dia 1",
					 "Por que você deve escolher Xamarin como plataforma mobile?",
					"Xamarin é nativo? Xamarin é produtivo? Muitos ainda tem essas dúvidas, mas não tem problema, vamos esclarecer! Nessa palestra vamos sanar essas questões mostrando um exemplo bem simples de um app para Android desenvolvido com Java, outro para iOS desenvolvido com Swift e o mesmo app para ambas as plataformas desenvolvido com Xamarin em linguagem C#. Duvido que depois dessa palestra você continue com dúvidas!",
					new DateTime(2017,08,21,21,00,00),
					new Speaker("Ione Souza Junior","Desenvolvedor Mobile","https://avatars3.githubusercontent.com/u/519642?v=4&s=460"),
					"21:00h - 22:00h"),
				new Talk(
					 "Dia 1",
					 "Como modificar a aparência e comportamento dos componentes em Xamarin.Forms utilizando Effects",
					"Nesta palestra vamos entender um pouco dessa magia onde um componente em Xamarin.Forms se transforma num componente Android ou iOS e em como ter acesso as propriedades nativas de cada componente para que possamos modificá-las de acordo com a necessidade do projeto.",
					new DateTime(2017,08,21,22,00,00),
					new Speaker("Valerio Ferreira","Microsoft MVP","http://xoweek.online/images/valerio.png"),
					"22:00h - 23:00h"),
				new Talk(
					 "Dia 1",
					 "Deixe seu aplicativo inteligente com Xamarin e Serviços Cognitivos!",
					"A apresentação será iniciada com uma introdução a definição de serviços cognitivos e compreensões de padrões de linguagens. Em seguida, como podemos integrar xamarin a um serviço cognitivo. Na introdução será utilizado slides, para melhor compreensão das definições, nos outros momentos códigos e exemplos.",
					new DateTime(2017,08,21,23,00,00),
					new Speaker("Jucinei Santos","Mobile Developer","https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/8/005/0a9/060/35b9e62.jpg"),
					"23:00 - 00:00h"),
				new Talk(
					 "Dia 2",
					 "In-App Purchases em aplicativos móveis",
					"Muitas vezes os desenvolvedores precisam monetizar seus aplicativos móveis e para isso existem diversas maneiras. Uma delas é o In-App Purchases (IAPs) ou simplesmente \"Compras dentro do aplicativo\". Os IAPs possuem diversas maneiras de serem aplicadas dentro de aplicativos, como adicionar novos recursos, remover anúncios ou comprar moedas para um jogo. Nessa palestra vamos fazer uma análise sobre os IAPs e como adicioná-los em aplicativos moveis. Tópicos abordados: - O que são IAPs - Tipos de IAPs - Como começar - Como integrar com Android e iOS - Fazendo compras",
					new DateTime(2017,08,22,21,00,00),
					new Speaker("Diego Castro","Technical Evangelist na Microsoft Innovation Center Campinas","https://pt.gravatar.com/userimage/83987143/ebdb30b5ce4acf3fd0a77cc1de00e392.jpg?size=500"),
					"21:00h - 22:00h"),
				new Talk(
					 "Dia 2",
					 "Sua aplicação Forms com Prism",
					"Como desenvolver seu app Forms com Prism e torná-lo muito mais do que ele já seria!",
					new DateTime(2017,08,22,22,00,00),
					new Speaker("Rodrigo Amaro","Desenvolvedor Mobile","https://avatars0.githubusercontent.com/u/6537000?v=4&s=460"),
					"22:00 - 23:00h"),
				new Talk(
					 "Dia 2",
					 "Xamarin Forms - Utlizando conexão bluetooth com devices BLE (Bluetooth Low Energy)",
					"Conectando com devices BLE no Xamarin forms utlizando a biblioteca Plugin.BLE. - Conhecendo a biblioteca Plugin.BLE - Criando a aplicação de teste - Descobrindo os devices - Registrando um device - Registrando um evento de update no Xamarin - Atualizando a UI",
					new DateTime(2017,08,22,23,00,00),
					new Speaker("Raul Menezes","Software Engineer at Brain Tunnelgenix Technologies Corp","https://avatars3.githubusercontent.com/u/1154679?v=4&u=b50f1e4e2f3eb942475e13f0c907a9ba939c1211&s"),
					"23:00h - 00:00h")
			};
	}
}