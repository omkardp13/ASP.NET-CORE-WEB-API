DBContext class --->
1.It is class that represent session with a database and provides set of API's for performing database operations.
2.The DbContext class is responsible for the maintaining the connection to the database,tracking changes to data and performing database operations such as inserting,updating & deleting
3.It is provide a way to define database schema using entity classes or domain classes tha which maps directly to database tables.
4.we can say that Dbcontext class is a bridge between our domain model classes and database





Controller    <-------------> DbContext  <--------------------> Database

5.DbContext class is the primary class that is the responsible for interacting with the database and performing CRUD operations on our database tables.

DBSet --->a Dbset is property of DbContext class that represents collection of entities in the database.
