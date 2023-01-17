# uCondo Teste de aplicação Galdino

# Para rodar o projeto é necessário seguir estes passos.

1 - Há um arquivo docker-compose.yml na pastas src/uCondo.Galdino

# Rode os seguintes comandos:
```bash
cd uCondo/src/UCondo.Galdino
docker-compose up
```
1.1 - Dentro da pasta SQL existe 3 arquivos
  1.1.1 - InitialDataBase.sql, este arquivo inicia a base de dados criando um banco uCondo
  
  1.1.2 - createTableUser.sql, esse arquivo gera algumas tabelas iniciais para que a API funcione e tenha um login
    1.1.2.1 - Este login será necessário realizar as chamadas da API que auta como Oauht2, utilizando uma Bearer Token, que é gerado pela rota /Auth
    
  1.1.3 - init-uCondo.sh, este arquivo executa um comando via cmd que roda as querys dentro do banco (não é necessário rodar o docker ja faz isso)
  
1.2 - Isso irá subir duas instancias, uma SqlServer e uma Kibana (para observability da aplicação)

2. Rodar a aplicação
```bash
cd uCondo/src/UCondo.Galdino
dotnet run
```

# Com isso teremos a API no rodando 

3. Dentro do projeto existe um arquivo chamado uCondoCollection.json, que pode ser utilizado para gerar a collection via insomnia


Fico no aguardo 

[MIT](https://github.com/EmersonGaldino)
