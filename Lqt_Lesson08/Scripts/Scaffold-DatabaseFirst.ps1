# Chay trong thu muc chua LqtBookStore.csproj.
# Truoc khi chay: tao database BookStoreDB bang Database/BookStoreDB.sql.
# Sua Server=.; neu SQL Server tren may ban dung instance khac.

$connection = "Server=.;Database=BookStoreDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true"

# Scaffold-DbContext tao lai entity va DbContext tu database hien co.
# -Force ghi de cac model/context cu; hay commit Git truoc khi chay lai.
Scaffold-DbContext $connection Microsoft.EntityFrameworkCore.SqlServer `
    -OutputDir Models `
    -ContextDir Data `
    -Context BookStoreDbContext `
    -Namespace LqtBookStore.Models `
    -ContextNamespace LqtBookStore.Data `
    -NoOnConfiguring `
    -DataAnnotations `
    -Force
