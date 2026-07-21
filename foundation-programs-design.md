# Foundation Programs Design

## Program 1: YouTube Videos (Abstraction)

This program models a simplified YouTube-style system where Video objects contain a list of Comment objects, demonstrating the abstraction principle by exposing only relevant operations (add/get comments) while hiding internal list management.

```mermaid
classDiagram
    class Video {
        -title: string
        -author: string
        -lengthInSeconds: int
        -comments: List~Comment~
        +Video(title: string, author: string, lengthInSeconds: int)
        +AddComment(comment: Comment): void
        +GetCommentCount(): int
        +GetComments(): List~Comment~
        +GetTitle(): string
        +GetAuthor(): string
        +GetLengthInSeconds(): int
    }

    class Comment {
        -commenterName: string
        -text: string
        +Comment(commenterName: string, text: string)
        +GetCommenterName(): string
        +GetText(): string
    }

    Video "1" --> "0..*" Comment : contains
```

### Program flow

1. Program.cs creates 3-4 Video objects, setting title/author/length on each via constructor.
2. For each video, create 3-4 Comment objects (name + text) and add them via `AddComment()`.
3. Put all videos into a `List<Video>`.
4. Loop through the list; for each video print title, author, length, and `GetCommentCount()`, then loop through `GetComments()` and print each comment's name and text.

## Program 2: Online Ordering (Encapsulation)

This program models an order-processing system where Order, Customer, Address, and Product classes encapsulate their data behind private fields, exposing behavior through public methods while hiding internal state.

```mermaid
classDiagram
    class Address {
        -street: string
        -city: string
        -stateOrProvince: string
        -country: string
        +Address(street: string, city: string, stateOrProvince: string, country: string)
        +GetStreet(): string
        +SetStreet(value: string): void
        +GetCity(): string
        +SetCity(value: string): void
        +GetStateOrProvince(): string
        +SetStateOrProvince(value: string): void
        +GetCountry(): string
        +SetCountry(value: string): void
        +IsInUSA(): bool
        +GetFullAddress(): string
    }

    class Customer {
        -name: string
        -address: Address
        +Customer(name: string, address: Address)
        +GetName(): string
        +SetName(value: string): void
        +GetAddress(): Address
        +SetAddress(value: Address): void
        +LivesInUSA(): bool
    }

    class Product {
        -name: string
        -productId: string
        -price: double
        -quantity: int
        +Product(name: string, productId: string, price: double, quantity: int)
        +GetName(): string
        +SetName(value: string): void
        +GetProductId(): string
        +SetProductId(value: string): void
        +GetPrice(): double
        +SetPrice(value: double): void
        +GetQuantity(): int
        +SetQuantity(value: int): void
        +GetTotalCost(): double
    }

    class Order {
        -products: List~Product~
        -customer: Customer
        +Order(customer: Customer)
        +GetProducts(): List~Product~
        +SetProducts(value: List~Product~): void
        +GetCustomer(): Customer
        +SetCustomer(value: Customer): void
        +GetTotalPrice(): double
        +GetPackingLabel(): string
        +GetShippingLabel(): string
    }

    Order "1" --> "1" Customer : has
    Order "1" --> "1..*" Product : contains
    Customer "1" --> "1" Address : has
```

### Program flow

1. Create at least 2 Address objects (make sure at least one has country "USA" and at least one does not, to exercise both shipping cost branches).
2. Create at least 2 Customer objects, each linked to one of the addresses.
3. Create several Product objects with varying prices and quantities.
4. Create at least 2 Order objects, each containing 2-3 products and one customer.
5. For each order, call and print `GetPackingLabel()`, `GetShippingLabel()`, and `GetTotalPrice()`, and display the results.
