# Structural Design Patterns in C#

Dự án minh họa **7 Structural Design Patterns** theo tài liệu [Refactoring.Guru](https://refactoring.guru/design-patterns/structural-patterns).

Được tạo để chạy trên **Visual Studio 2022** (.NET 8.0).

## Các Pattern được implement

| Pattern     | Mô tả ngắn |
|-------------|------------|
| **Adapter** | Cho phép các đối tượng có interface không tương thích làm việc với nhau |
| **Bridge**  | Tách abstraction khỏi implementation để phát triển độc lập |
| **Composite** | Compose objects thành cấu trúc cây và làm việc với chúng như một object |
| **Decorator** | Gắn thêm hành vi mới cho object bằng cách bọc chúng trong wrapper |
| **Facade**  | Cung cấp interface đơn giản cho một hệ thống phức tạp |
| **Flyweight** | Chia sẻ state chung để tiết kiệm bộ nhớ khi có nhiều object tương tự |
| **Proxy**   | Cung cấp đối tượng thay thế, kiểm soát quyền truy cập vào object gốc |

## Cách mở project bằng Visual Studio 2022

1. Clone hoặc tải repo về máy
2. Mở file `StructuralDesignPatterns.sln` bằng Visual Studio 2022
3. Chọn project muốn chạy (ví dụ `Adapter`) làm **Startup Project**
4. Nhấn `F5` hoặc `Ctrl + F5` để chạy

## Cách chạy bằng .NET CLI

```bash
cd Adapter
dotnet run

cd ../Bridge
dotnet run

# Tương tự với các pattern khác
```

## Cấu trúc Solution

```
StructuralDesignPatterns/
├── StructuralDesignPatterns.sln
├── README.md
├── Adapter/
├── Bridge/
├── Composite/
├── Decorator/
├── Facade/
├── Flyweight/
└── Proxy/
```

Mỗi folder là một Console App độc lập chứa ví dụ Conceptual của pattern tương ứng.

## Nguồn tham khảo

- [Refactoring.Guru - Structural Design Patterns](https://refactoring.guru/design-patterns/structural-patterns)
- Official C# examples: [RefactoringGuru/design-patterns-csharp](https://github.com/RefactoringGuru/design-patterns-csharp)

## License

Code ví dụ mang tính giáo dục, tham khảo từ Refactoring.Guru.
