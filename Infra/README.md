Camada de infraestrutura: é dividida em duas sub-camadas
- Data: realiza a persistência com o banco de dados, utilizando, ou não, algum ORM.
- Cross-Cutting: uma camada a parte que não obedece a hierarquia de camada. Como o próprio nome diz, essa camada cruza toda a hierarquia. Contém as funcionalidades que pode ser utilizada em qualquer parte do código, como, por exemplo, validação de CPF/CNPJ, consumo de API externa e utilização de alguma segurança.
Possui referências da camada Domain.