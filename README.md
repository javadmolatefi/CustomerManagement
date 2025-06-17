# 🧾 Customer Management application

A full-stack web application built using **ASP.NET Core (.NET 8)**, **Blazor WebAssembly**, **Clean Architecture**, **CQRS**, and **Entity Framework Core**.

This app allows managing Customers and Cities with full CRUD, authentication (JWT + Identity) and export feature.  
The Blazor UI communicates securely with the Web API via JWT authentication.

---

## 📁 Project Structure
CustomerManagement/

│

├── Src/

│ ├── API/

│ │ └── CustomerManagement.API // ASP.NET Core Web API

│ ├── Site/

│ │ └── CustomerManagement.BlazorUI // Blazor WebAssembly frontend

│ ├── Domain/

│ │ └── CustomerManagement.Domain // Domain layer

│ ├── Application/

│ │ └── CustomerManagement.Application // CQRS, DTOs, Facades

│ └── Infrastructure/

│ └── CustomerManagement.Infrastructure // EF Core, Identity, Repos


---

## 🧪 Features

- ✅ Clean Architecture with separated layers
- ✅ JWT Authentication & ASP.NET Identity
- ✅ Customer & City CRUD operations
- ✅ Export data to a `.txt` file (TAB-separated)
- ✅ Blazor WebAssembly frontend with modal forms
- ✅ Secure Authenticated Access
- ✅ Logging, and ready for Docker

---

## 🚀 How to Run the Project (Locally)

> Prerequisites:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (localdb or full)
- Visual Studio 2022+ or VS Code

### ✅ 1. Clone the Repository

```bash
git clone https://github.com/javadmolatefi/CustomerManagement.git
cd CustomerManagement
```
### ✅ 2. Apply EF Core Migrations
- Make sure the Startup Project is:
CustomerManagement.API

> Then use one of these:
- Package Manager Console (Visual Studio):
```bash
Update-Database -context ApplicationDbContext
```
- OR .NET CLI:
```bash
dotnet ef database update \
  -p Src/Infrastructure/CustomerManagement.Infrastructure \
  -s Src/API/CustomerManagement.API \
  --context ApplicationDbContext
```

> Do the same for IdentityDbContext:
- Package Manager Console (Visual Studio):
```bash
Update-Database -context IdentityDbContext
```
- OR .NET CLI:
```bash
dotnet ef database update \
  -p Src/Infrastructure/CustomerManagement.Infrastructure \
  -s Src/API/CustomerManagement.API \
  --context IdentityDbContext
```

### ✅ 3. Run the APP
> In Visual Studio:
- Set CustomerManagement.API and CustomerManagement.BlazorUI as startup projects and run (F5)
> Or from terminal:
```bash
cd Src/API/CustomerManagement.API
dotnet run
```
API should be available at:
https://localhost:7296

> In another terminal:
```bash
cd Src/Site/CustomerManagement.BlazorUI
dotnet run
```
UI should be available at:
https://localhost:7056

---

## 🔐 Authentication
You can register a user via the /register page in the Blazor UI.

After login, you’ll get access to protected pages like:

/customer
/city
/

The UI shows the logged-in user's name and allows logout.
