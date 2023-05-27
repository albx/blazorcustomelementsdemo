# Blazor Custom Elements

This repository contains some sample using Blazor Custom Elements to reuse Blazor components in other technologies.

## Prerequisites

.NET 7 SDK must be installed.

The project to run are the following.

- **MyAwesomeBlog.Web.Site**: is the ASP.NET Core MVC project which represents the frontend of the blog.
- **MyAwesomeBlog.Web.Api**: is the ASP.NET Core WebApi project which exposes the endpoints to manage the comments of a post
- **myawesomeblog.backoffice**: is the React project which represents the backoffice area

## Branches

The branch [**main**](https://github.com/albx/blazorcustomelementsdemo) contains the starting point of the project.

The branch [**blazorcustomelements**](https://github.com/albx/blazorcustomelementsdemo/tree/blazorcustomelements) contains the implementation of the Blazor component which needs to be added to the React and ASP.NET Core MVC project.

The branch [**blazorcustomelements-end**](https://github.com/albx/blazorcustomelementsdemo/tree/blazorcustomelements-end) contains the implementation of the post management using Blazor Custom Elements both in the React and the ASP.NET Core MVC projects.

The branch [**blazorcustomelements-css**](https://github.com/albx/blazorcustomelementsdemo/tree/blazorcustomelements-css) contains an implementations of the custom elemnts using CSS isolation.

The branch [**eventcallbacks**](https://github.com/albx/blazorcustomelementsdemo/tree/eventcallbacks) contains the implementation of the custom elements including the management of EventCallbacks and dynamic parameters.

The branch [**faking-authorization**](https://github.com/albx/blazorcustomelementsdemo/tree/faking-authorization) contains a sample using a simple and fake authorization management to view the delete operation for a post comment.

## Slides

- [**BlazorConf 2023**](./slides/BlazorConf2023.pdf)