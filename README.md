# Employee-Organizer

### Technologies

ASP.NET CORE 5 / React.js v 18.1

#### Nuget packages

- Microsoft.EntityFrameWorkCore.SqlServer v5.017
- Microsoft.EntityFrameWorkCore.Relational v5.017
- Microsoft.EntityFrameWorkCore.Tools v5.017
- Microsoft.AspNetCore.Mvc.NewtonsoftJson v5.017
  - For handling circular references
- Microsoft.AspNetCore.Authentication.JwtBearer v5.017
  - I've choosen JWT token for authentication
- BCrypt.Net-Next v4.03
  - For password encryption

#### React dependencies

- Axios v0.27
- React-redux v8
- Redux-persist v6
- Redux-thunk v2.4
- React-bootsrap v2.4
- Fontawesome v6.1
- React-router-dom v6.3

#### Comments

I've changed the provided <strong>ILogicService<TEntity></strong>
  - Changed the <strong>Task DeleteAsync(TEntity entity)</strong> to receive an Id as a parameter
  - Changed the <strong>Task<IQueryable<TEntity>> Query(..)</strong> to a synchronous method
    - In my understanding IQueryable is the structure of the query but it'll not create a request to the database therefore I could not understand why it should be async.
   - I was missing a GetAll() method but I didn't want to change the interface more so I used the <strong>Query()</strong> method to retreive all the records from a table.

