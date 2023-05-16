dotnet publish .\MyAwesomeBlog.Web.UI.Blazor.csproj -c Release -o .\bin\Release\published

Copy-Item -Path ".\bin\Release\published\wwwroot\_framework" -Destination "..\myawesomeblog.backoffice\public\_framework" -Recurse
Copy-Item -Path ".\bin\Release\published\wwwroot\_content" -Destination "..\myawesomeblog.backoffice\public\_content" -Recurse
Copy-Item -Path ".\bin\Release\published\wwwroot\MyAwesomeBlog.Web.UI.Blazor.styles.css" -Destination "..\myawesomeblog.backoffice\public"