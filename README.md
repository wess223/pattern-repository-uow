# Demo Aplicando Pattern Repository e Unit Of Work

## Pattern Repository
  * Repositório Genérico: Ponto negativo é que você pode acabar ferindo o princípio ISP:_Princípio da segregação de interface_ do SOLID. Ex: pode existir cenários que a classe que herda de um repositório genérico não precise ou não pode implementar todos os metódos dela.

  

## Pattern UoW(Unit Of Work)