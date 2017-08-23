# Prism Example App

App apresentado durante o Xamarin Online Week.

## Iniciando

Essas instruções fornecerão uma cópia do projeto em funcionamento em sua máquina local para fins de desenvolvimento e teste. Consulte a implantação de notas sobre como implantar o projeto em um sistema ao vivo.

## Pré-requisitos

É importante ter a versão mais recente do Xcode e também instalado o ** ANDROID SDK PLATFORM TOOLS 25.0.4 ** e o ** Android SDK (API 23) ** e / ou ** Android 7 (API 24) ** . Preferencialmente API 23.

## Instalando

```
Clone este repositório e abra a solução usando Visual Studio for Mac (preferencialmente) ou Visual Studio 2015 ou 2107 (ambos com as ferramentas Xamarin instaladas e atualizadas pelo canal STABLE)
```

## Plugins de terceiros (plug-ins via nuget)

These were the main plug-ins used

| Plug-ins|
| ------------------- |
|Prism Library|
|FFImageLoading|
|Image Circle|

### Prism Library

Utilizamos a biblioteca Prism para melhorar os recursos nativos MVVM da biblioteca Xamarin Forms e ter um melhor controle e desempenho ao longo da navegação dentro da aplicação. Além de diminuir o acoplamento no aplicativo, permitindo-nos maior capacidade de armazenamento
[Para mais informações, acesse aqui](https://github.com/PrismLibrary/Prism)

### FFImageLoading

Usamos o plug-in FFImageLoading para maior agilidade e flexibilidade ao trabalhar com imagens, permitindo tratar o borrão mais simples e a possibilidade de trabalhar com cache
[Para mais informações, acesse aqui](https://github.com/luberda-molinet/FFImageLoading)

### Image Circle

Usamos o plug-in Image Circle para dar a característica circular nas imagens e aplicar bordas nestas.
[Para mais informações, acesse aqui](https://github.com/jamesmontemagno/ImageCirclePlugin)

## Construído com

* [Xamarin Forms](https://www.nuget.org/packages/Xamarin.Forms/) - Xamarin Forms (Last Beta Version)
* [Mono](http://www.mono-project.com/docs/about-mono/releases/4.8.0/) - Mono (Last Stable Version)

## Autor

* **Rodrigo Amaro**

## Licença

Este projeto está licenciado sob a licença MIT