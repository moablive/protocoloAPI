<div style="display: inline_block">
<h2>Tecnologias </H2>
    <img alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" />
    <img alt="MySQL" src="https://img.shields.io/badge/MySQL-00000F?style=for-the-badge&logo=mysql&logoColor=white" />

</div>

<H2>Pacotes Nuget <img alt="Nuget" src="https://img.icons8.com/?size=256&id=CU53cHqG1K0l&format=png" width="50" height="50" /></h2>

Microsoft.EntityFrameworkCore <br>
Microsoft.EntityFrameworkCore.Design <br>
Pomelo.EntityFrameworkCore.MySql <br>

<h2>Comandos Para Subir o Banco Mysql Docker do Projeto</h2>

```powershell
docker run -d --name atendimentoEmpresaMVC -p 3306:3306 -v atendimentoEmpresaMVC :/var/lib/mysql -e MYSQL_ROOT_PASSWORD=1234 -e MYSQL_PASSWORD=1234 -e MYSQL_ROOT_HOST=% mysql:5.7
```

<h2>Comandos Para Rodar no diretorio  do Projeto</h2>

```powershell
dotnet ef migrations add init
```

```powershell
dotnet ef database update
```

```powershell
dotnet build
```

<H2>OBS!</H2>
Devido ao projeto não ter uma camada de frontend <br>
a captura e o registro de informações para entidades de pessoa física e jurídica <br> 
bem como seus respectivos endereços<br>
foram projetados para serem processados separadamente. <br> <br>

Como resultado, o identificador (ID) associado a essas entidades precisa ser adicionado posteriormente por meio da interface Swagger da API. <br><br>

Este processo permite associar corretamente as informações de pessoa física ou jurídica com seus respectivos endereços, garantindo uma integração eficaz na ausência de uma interface de usuário voltada ao usuário final.
