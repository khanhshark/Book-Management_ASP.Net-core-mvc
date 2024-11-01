# Book-Management_ASP.Net-core-mvc
Đây là ứng dụng web được xây dựng bằng ASP.NET Core MVC, thiết kế để quản lý sách với hệ thống phân quyền dựa trên vai trò. Ứng dụng cho phép quản trị viên (admin) quản lý sách, trong khi người dùng thông thường có quyền truy cập hạn chế.

## Tính năng

- **ASP.NET Core MVC**: Sử dụng mô hình thiết kế Model-View-Controller (MVC) giúp tổ chức và mở rộng mã nguồn dễ dàng.
- **Phân quyền theo vai trò**: 
  - Người dùng admin có toàn quyền kiểm soát bộ sưu tập sách, bao gồm thêm, sửa và xoá sách.
  - Người dùng thông thường chỉ có thể xem chi tiết sách và bị hạn chế quyền.
- **CRUD Operations**: Admin có thể thực hiện các thao tác Thêm, Đọc, Sửa và Xoá (Create, Read, Update, Delete) trên sách.
- **Xác thực và quản lý người dùng**: Tích hợp ASP.NET Core Identity để xác thực người dùng và quản lý vai trò.
- **Kết nối cơ sở dữ liệu**: Sử dụng Entity Framework Core để làm việc với cơ sở dữ liệu SQL, lưu trữ thông tin sách và dữ liệu người dùng.