Postman Collection Documentation To Test API

1. Token Generation: POST /api/token/generate-token
Request Type: POST
URL: https://localhost:5001/api/token/generate-token
Request Body (JSON):
json
Copy code
{
  "username": "john",   // Replace with any username
  "role": "Admin",      // Replace with User or Admin role
  "age": 18             // Replace with the user's age
}
Expected Response:
json
Copy code
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."  // JWT token
}
Description:
This endpoint is used to generate a JWT token with claims (role and age).
The generated token is required for all the secure endpoints that follow.
Postman Setup:
In Body tab, select raw, then choose JSON and use the payload shown above.
Click Send to get the JWT token, which will be used for the following requests.
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2. Public Endpoint: GET /api/auth/public
Request Type: GET
URL: https://localhost:5001/api/auth/public
Authorization:
In Authorization tab, select Bearer Token.
Paste the JWT token from the previous step.
Expected Response:
json
Copy code
{
  "message": "This is a public endpoint for authenticated users."
}
Description:
Accessible by any authenticated user with a valid token.
No role or specific policy required.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
3. Admin-Only Endpoint: GET /api/auth/admin
Request Type: GET
URL: https://localhost:5001/api/auth/admin
Authorization:
In Authorization tab, select Bearer Token.
Paste the JWT token that contains the Admin role.
Expected Response:
json
Copy code
{
  "message": "This is an Admin-only endpoint."
}
Description:
Requires the Admin role in the JWT token.
Users without the Admin role will receive a 403 Forbidden response.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
4. Age-Restricted Endpoint: GET /api/auth/age-restricted
Request Type: GET
URL: https://localhost:5001/api/auth/age-restricted
Authorization:
In Authorization tab, select Bearer Token.
Paste the JWT token that contains the Age claim of 18 or more.
Expected Response:
json
Copy code
{
  "message": "You are at least 18 years old."
}
Description:
Requires an Age claim of 18 or greater in the JWT token.
Users without this condition will receive a 403 Forbidden response.
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
5. Admin and Age-Restricted Endpoint: GET /api/auth/admin-age-restricted
Request Type: GET
URL: https://localhost:5001/api/auth/admin-age-restricted
Authorization:
In Authorization tab, select Bearer Token.
Paste the JWT token that contains both the Admin role and an Age claim of 18 or more.
Expected Response:
json
Copy code
{
  "message": "You are an Admin and at least 18 years old."
}
Description:
Requires both:
The Admin role.
An Age claim of 18 or more in the JWT token.
Users who do not meet both conditions will receive a 403 Forbidden response.
