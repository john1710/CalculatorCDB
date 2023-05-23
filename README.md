O projeto consiste em duas partes principais: o frontend em Angular e o backend em ASP.NET Web API.

# Frontend em Angular:
O frontend é desenvolvido utilizando o framework Angular. Ele é responsável por fornecer uma interface de usuário amigável para que o usuário possa inserir o número de meses e o valor do investimento para calcular o CDB.

O frontend consiste em uma página com um formulário contendo campos para o número de meses e o valor do investimento. Quando o usuário preenche esses campos e clica em um botão de "Calcular", os valores são enviados para o backend por meio de uma requisição HTTP.

Além disso, o frontend também exibe o resultado do cálculo do CDB retornado pelo backend. Essa informação é atualizada na tela assim que a resposta do backend é recebida.

# Backend em ASP.NET Web API:
O backend é desenvolvido utilizando o framework ASP.NET Web API. Ele recebe as requisições do frontend, realiza o cálculo do CDB com base nos parâmetros fornecidos e retorna o resultado para o frontend.

O backend expõe um endpoint HTTP para receber as requisições do frontend. Esse endpoint é configurado para aceitar requisições GET com os parâmetros de número de meses e valor do investimento na query da requisição.

Ao receber a requisição, o backend valida os parâmetros recebidos, realiza o cálculo do CDB com base nos valores fornecidos e retorna o resultado para o frontend. O resultado é enviado como uma resposta HTTP contendo o valor do CDB calculado.

O cálculo do CDB pode ser feito utilizando fórmulas matemáticas específicas, considerando a taxa de juros vigente e o período de tempo. O backend deve implementar essa lógica de cálculo.

Em resumo, o projeto consiste em um frontend Angular que permite ao usuário inserir o número de meses e o valor do investimento, e um backend ASP.NET Web API que recebe esses dados, realiza o cálculo do CDB e retorna o resultado para o frontend. Com essa estrutura, o usuário pode facilmente calcular o CDB com base nos parâmetros desejados.

# Steps to Run
- Back-end:
 1. Navegue até a pasta API e execute o seguinte commando:
``` dotnet run ```

- Front-end:
 1. Navegue até a pasta web-app e execute os seguintes commandos:
 2. ```npm install``` <br/> ``` ng serve ```
 
- Testes:
 1. Navegue até a pasta Test  e execute o seguinte commando:
 ``` dotnet test ```
