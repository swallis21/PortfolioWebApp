# Portfolio
This is the code for my portfolio website available at https://swportfolio.dev/. It is under continuous development. Feel free to take a look around.

# Details
The website is made with .NET Core, using Clean Architecture and the CQRS pattern. This splits the solution into six projects:
1. Domain - the innermost ring containing database models.
2. Application - where the logic for the application's features is defined; all viewmodels, commands, and queries are located here, as well as dependency injections which make the application work.
3. Infrastructure - the database logic layer which handles code-first Entity Framework connections to external databases. I don't have any currently, so it's empty.
4. API - a web layer which exposes API endpoints with no views. If you run this project on its own, you can access the Swagger UI.
5. Presentation - the front-end layer which contains all of the views and controllers, as well as static web assets.
6. Unit Tests - the automated regression testing layer.

# CI/CD
The repo uses Github Actions to create a CI/CD pipeline. Code pushed to a PR branch is automatically unit tested, and when merged, the application is automatically compiled and published to AWS Elastic Beanstalk. HTTPS encryption is automatically managed by a few scripts which install Certbot onto any instance the application is published to. In short, all building, testing, and deployment is completely automated by the Git repo.