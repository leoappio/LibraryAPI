# Library API
## Uma Api para uma biblioteca.
<http://leolibraryapi.azurewebsites.net/swagger/index.html>

### Features
- [x] Autenticação e Autorização via Bearer Token
- [x] Cadastro de Clientes
- [x] Cadastro de Livros
- [x] Pegar livro emprestado
- [x] Devolver livro
- [x] Visualizar todos os livros emprestados para um cliente

###Tutorial

1. No Método Post Auth, clique em Try it out, coloque o email e senha para autenticação e clique em execute
2. Com o token recebido, clique no botão "Authorize" no canto superior direito, cole apenas o token e clique em "Authorize"
3. Pronto, você está autenticado para testar os endpoints disponíveis.
4. Caso você receba o erro 401, significa que algo de errado aconteceu com o token, tente novamente seguir os passos acima.
