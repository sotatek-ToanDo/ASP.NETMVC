##Controller
-La  một lớp kể thùa từ lớp Controler: Microsoft.AspNetCore.Controller
Action trong controller là 1 method public (khong duoc static)
Action tra ve bat ki kieu du lieu nao thunog la IACtionResult
Cac dich vu Ịnect vao trong controller qua ham tao

##View
la file .cshtml
View cho Action Luu tai /View/ControllerName/ActionName.cshtml

{0} - ten Action
{1} - ten controller
{2} - ten Area
option.viewLocationFormats.As("MyView/{1}/{0}" + RazorViewEngine.ViewExtention);
### Truyen du lieu sang View
Model
ViewData
ViewBag
TempData

##area Controller
 la ten dung de routing
 LÀ cấu trũc thu mục chưa MVC
 Thiết lập Area cho container bằng [Area("AreaName")]
 Tạo cấu trúc thư mục

 dotnet aspnet-condegenerator area Product
 truyen nhieu data ---> asp-all-route-data