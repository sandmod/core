<div align="center">
  <img alt="Sandmod Core" height="300px" src="https://avatars.githubusercontent.com/u/142268940">
</div>

![Discord](https://img.shields.io/discord/1018463122144636980?style=for-the-badge&label=Discord&color=3273EB)
![GitHub Repo stars](https://img.shields.io/github/stars/sandmod/core?style=for-the-badge&logoColor=3273EB&color=3273EB)
![Asset.Party References](https://img.shields.io/badge/dynamic/xml?url=https%3A%2F%2Fasset.party%2Fsandmod%2Fcore&query=%2F%2Fdiv%5Btext()%3D%22Referenced%22%5D%2Fparent%3A%3Adiv%2Fdiv%5Bcontains(%40class%2C%20'value')%5D&suffix=%20References&style=for-the-badge&label=asset.party&color=3273EB)![Asset.Party Collections](https://img.shields.io/badge/dynamic/xml?url=https%3A%2F%2Fasset.party%2Fsandmod%2Fcore&query=%2F%2Fdiv%5Bcontains(%40class%2C%20'collections')%5D%2Fspan%5Bcontains(%40class%2C%20'count')%5D&suffix=%20Collections&style=for-the-badge&label=&color=3273EB)![Asset.Party Likes](https://img.shields.io/badge/dynamic/xml?url=https%3A%2F%2Fasset.party%2Fsandmod%2Fcore&query=%2F%2Fdiv%5Bcontains(%40class%2C%20'rate_like')%5D%2Fspan&suffix=%20Likes&style=for-the-badge&label=&color=3273EB)![Asset.Party Favourites](https://img.shields.io/badge/dynamic/xml?url=https%3A%2F%2Fasset.party%2Fsandmod%2Fcore&query=%2F%2Fdiv%5Bcontains(%40class%2C%20'favourite')%5D%2Fspan%5Bcontains(%40class%2C%20'count')%5D&suffix=%20Favourites&style=for-the-badge&label=&color=3273EB)

> Core library

> Sandmod provides all kinds of frameworks for developers.  
> This way we can all have on a shared experience where addon incompatibility is no issue anymore.

Sandmod core is the core library of Sandmod. `You probably already guessed that :)`

The library contains the shared structures and utilities of Sandmod.

## The library

The [OfflineClient](code/Client/OfflineClient.cs) is used to represent an client that is not on the server.

The classes of [Provider](code/Provider) namespace are used for auto-injection.

## Setup

To add this library to your s&box editor, simply clone the [Sandmod Core](https://asset.party/sandmod/core) project from [asset.party](https://asset.party/sandmod/core).
