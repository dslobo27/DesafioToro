# DesafioToro

Projeto visando atender a TORO-004.

Projeto de backend, pode ser encontrado no diretório "api", desenvolvido em DDD com uma arquitetura em camadas.
Projeto frontend, pode ser encontrado no diretório "app", desenvolvido em Angular.

Obs.: Foi acrescentado um fluxo de login, mas o objetivo principal é apresentar o desenvolvimento necessário à entrega da TORO-004.

- Para instalação de dependências, executar o restore do nuget packages e npm install
- Para execução do projeto Backend, no visual studio, F5.
- Para execução do projeto Frontend, no terminal, use o comando ng serve -o.
- Para execução dos testes Backend, no menu do visual studio, na guia "test", escolha a opção "test explorer" e clique na opção "Run All".
- Para execução dos testes Frontend, no terminal, use o comando npm test.

Foram criados dois usuários de acesso, e os dados são:

- César Tralli
Cpf: 17811768097
Senha: 123
Saldo: R$ 10,00 (Para o teste de saldo insuficiente)

- Edmilson Ávila
Cpf: 99122162020
Senha: 123
Saldo: R$ 300,00

Foi disponibilizado um banco SQL Server para a aplicação:
Server: plesk20.nspmanaged.com,1431
Base: Desafio
Usuário: usr_toro
Senha: jjfK9nhYk9jP7sq

Alguns comandos mais utilizados durante o desenvolvimento:
- truncate table ativosusuario;
- update contascorrentes set saldo = 300;
- select * from usuarios;
- select * from Ativos;
- select * from AtivosUsuario;

Desde já agradeço pela oportunidade de realizar o desafio, foi importante pra recordar conhecimentos e adquirir novas habilidades.
