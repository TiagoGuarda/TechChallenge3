# Tech Challenge 3
Solution de um blog de notícias contendo uma API de Autenticação e uma outra API para Gerenciamento das notícias do blog.

## Enpoint de Autenticação:
<b>[POST] {url}/api/Autenticacao/Login</b><br>
<i>Método utilizado para gerar um bearer token para ser utilizado nos métodos da API de gerenciamento.</i>

<b>HEADER</b>
> Nenhum

<b>BODY</b>
> { "nome" : "{nome do usuário}", "senha" : "{senha do usuário}" }

<b>RETORNO</b>
> { "usuario": { "id": 1, "nome": "{nome do usuário}", "senha": "", "grupo": "{grupo do usuário}" }, "token": "{token gerado}" }


## Endpoints de Gerenciamento:
<b>[GET] {url}/api/Gerenciamento/Noticias</b><br>
<i>Método utilizado para retornar a lista de todas as notícias cadastradas no blog.</i>

<b>HEADER</b>
> Nenhum

<b>BODY</b>
> Nenhum

<b>RETORNO</b>
> [{"id":1,"titulo":"{Titulo 1}","descricao":"{Descricao 1}","conteudo":"{Conteudo 1}","dataPublicacao":"{Data Publicacao 1}","autor":"{Autor 1}","dataAtualizacao":"{Data Atualizacao 1}"},<br>{"id":2,"titulo":"{Titulo 2}","descricao":"{Descricao 2}","conteudo":"{Conteudo 2}","dataPublicacao":"{Data Publicacao 2}","autor":"{Autor 2}","dataAtualizacao":"{Data Atualizacao 2}"}]

<hr>
<b>[GET] {url}/api/Gerenciamento/Noticias/{id}</b><br>
<i>Método utilizado para retornar uma notícia identificada pelo número <b>id</b> cadastrada no blog.</i><br><br>

<b>HEADER</b>
> Nenhum

<b>BODY</b>
> Nenhum

<b>RETORNO</b>
> {"id":1,"titulo":"{Titulo 1}","descricao":"{Descricao 1}","conteudo":"{Conteudo 1}","dataPublicacao":"{Data Publicacao 1}","autor":"{Autor 1}","dataAtualizacao":"{Data Atualizacao 1}"}

<hr>
<b>[POST] {url}/api/Gerenciamento/Noticias</b><br>
<i>Método utilizado para adicionar uma notícia ao blog.</i><br><br>

<b>HEADER</b>
> Bearer Token gerado através do método /api/Autenticacao/Login

<b>BODY</b>
> {"id":0,"titulo":"{Novo Titulo}","descricao":"{Nova Descricao}","conteudo":"{Novo Conteudo}","dataPublicacao":"{Nova Data Publicacao}","autor":"{Novo Autor}","dataAtualizacao":"9999-12-31T00:00:00.000Z"}

<b>RETORNO</b>
> { "mensagem": "Registro adicionado com sucesso!" }

<hr>
<b>[PUT] {url}/api/Gerenciamento/Noticias</b><br>
<i>Método utilizado para atualizar uma notícia do blog.</i><br><br>

<b>HEADER</b>
> Bearer Token gerado através do método /api/Autenticacao/Login

<b>BODY</b>
> {"id":{Id da Notícia},"titulo":"{Titulo Atualizado}","descricao":"{Descricao Atualizada}","conteudo":"{Conteudo Atualizado}","dataPublicacao":"{Data Publicacao Atualizada}","autor":"{Autor Atualizado}","dataAtualizacao":"9999-12-31T00:00:00.000Z"}

<b>RETORNO</b>
> { "mensagem": "Registro atualizado com sucesso!" }

<hr>
<b>[DELETE] {url}/api/Gerenciamento/Noticias/{id}</b><br>
<i>Método utilizado para remover uma notícia do blog identificada pelo número <b>id</b>.</i><br><br>

<b>HEADER</b>
> Bearer Token gerado através do método /api/Autenticacao/Login

<b>BODY</b>
> Nenhum

<b>RETORNO</b>
> { "mensagem": "Registro removido com sucesso!" }
