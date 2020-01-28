<h3>Web Application created in ASP.NET Core 2.2 and Angular 8.</h3>
Simple application with database connection. Database built with code first approach in Entity Framework Core. 

<h4>Steps to run this application:</h4>
<ul>
    <li>Make sure that you have Agular 8 and .NET Core 2.2 on your computer</li>
    <li>Download myLibrary repository</li>
    <li>Open myLibrary.api in terminal and type command <code>dotnet build</code></li>
    <li>When project has been built, type <code>dotnet ef database update</code> this will create local database for application</li>
    <li>Run backend with <code>dotnet watch run</code></li>
    <li>Open myLibrary-SPA in second terminal and type <code>npm install</code></li>
    <li>When it finish installation type <code>ng serve</code></li>
    <li>Now open your browser and go to <code>http://localhost:4200/</code></li>
</ul>
