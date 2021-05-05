# Introduction 
Project to manage tasks creating list "TODO".

# Project Information Scope
1. Target Audience
- This is an internal project where any employee of Mr. Vibbraneo's company, who would like to have a list of items with sub-lists at a public address, which can be shared by email to one or more users and these , when they receive the link, they can collaborate.
2. Home screen
- Must be accessed at the base URL of the website (root) and contain explanations of how to create a new list, edit an existing one and delete
- The menu must contain the following items:
- About: explain what the ToDo List tool does
3. Create TO DO
- When entering any URL, it must be used to refer to a new ToDo List
- After creation, the user must be sent to the ToDo editing screen
4. Edit TO DO
- Using a URL already associated with a ToDo, the user can perform the following operations on a list of text items:
- Create a new item
- Edit an existing item
- Delete an existing item
- Organize the item as a sub-item of an existing item
- Move a sub-item out of the parent item, transforming it into another parent item or a sub-item of another item;
5. Delete TO DO
- As a user I can delete a ToDo that is mine
6. Share TO DO
- As a user I would like to share the ToDo URL that I am editing by email to one or more people
7 home screen
Must be accessed at the base URL of the website (root) and explanations of how to create a new list, edit an existing one and delete
The menu should contain the following items:
About: Explain what the Task List tool does

# Project Tecnical Information

<ol>
    <li>
        <dl>
            <dt>Initialize ASP.NET Identity</dt>
            <dd>
                You can initialize ASP.NET Identity when the application starts. Since ASP.NET Identity is Entity Framework based in this sample,
                you can create DatabaseInitializer which is configured to get called each time the app starts.
                <strong>Please look in Global.asax and App_Start\IdentityConfig.cs</strong>
                This code shows the following
                <ul>
                    <li>When should the Initializer run and when should the database be created</li>
                    <li>Create user</li>
                    <li>Create user with password</li>
                    <li>Create Roles</li>
                    <li>Add Users to Roles</li>
                </ul>
            </dd>
        </dl>
    </li>
    <li>
        <dl>
            <dt>Customize Table Name for AspNetUsers</dt>
            <dd>
                If you want to change the default table name for the Users table, then you can do so
                by overriding the default mapping of the EF Code First types to table names.
                <strong>Look in Models\AppModel.cs on how we override the table name in ModelCreating event of DbContext</strong>
                <a href="http://msdn.microsoft.com/en-US/data/jj591617">For more info on override ModelCreating please visit</a>
            </dd>
        </dl>
    </li>    
    <li>
        <dl>
            <dt>Claims</dt>
            <dd>
                You can store information about the user as Claims as well. This sample shows the different places where you can inject claims.
                <ul>
                    <li>Add claims to the Claims table when the User regsiters an account. Look in AccountController\Register action where I am storing Gender as a Claim</li>
                    <li>
                        Add a claim before the User Signs In. Look in AccountController\SignIn method where I am adding HomeTown as a claim. As compared to the previous case I
                        am not storing the HomeTownClaim in the database.
                    </li>
                    <li>In both these case the Claim is set on the IPrincipal when the User Signs In</li>
                </ul>
            </dd>
        </dl>
    </li>
    <li>
        <dl>
            <dt>Register a user, Login</dt>
            <dd>
                See the code in AccountController.cs and Register Action.
                See the code in AccountController.cs and Login Action.
            </dd>
        </dl>
    </li>
    <li>
        <dl>
            <dt>Basic Role Management</dt>
            <dd>
                Do Create, Update, List and Delete Roles.
                Only Users In Role Admin can access this page. This uses the [Authorize] on the controller.
            </dd>
        </dl>
    </li>
    <li>
        <dl>
            <dt>Basic User Management</dt>
            <dd>
                Do Create, Update, List and Delete Users.
                Assign a Role to a User.
                Only Users In Role Admin can access this page. This uses the [Authorize] on the controller.
            </dd>
        </dl>
    </li>
    <li>
        <dl>
            <dt>Associating ToDoes with User</dt>
            <dd>
                This example shows how you can create a ToDo application where you can associate ToDoes with a User.
                Following are the salient features of this sample.
                <ul>
                    <li>Create ToDo model and associate User in EF Code First. Goto Models\AppModel.cs </li>
                    <li>Only Authenticated Users can Create ToDo</li>
                    <li>When you create/list ToDo, we can filter by User. Look at TaskController</li>                    
                </ul>
            </dd>
        </dl>
    </li>
</ol>


# Project Kanban
Link to project using the methodology Kanban: https://trello.com/b/IerhPsKc/vibbraneo

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	SqlServer, Windows Environment
3.	Version 1.0

# Build and Test
1. Access the video by YouTube: 

# Reporting security issues and bugs
Security issues and bugs should be reported privately, via email, to developer by email richiebono@gmail.com. You should receive a response within 24 hours.

