#) What is Adapter Design Pattern in .Net core??
The Adapter Pattern is a structural design pattern that allows incompatible interfaces to work together by converting one interface into another that a client expects.

In .NET Core projects, it is used to:
✅ Integrate third-party APIs with different response formats.
✅ Allow legacy code to work with new interfaces.
✅ Enable dependency injection for flexible and scalable solutions.
✅ Ensure loose coupling and separation of concerns in application architecture.

#) In above health insurance aggregator project, we needed to fetch insurance plans from multiple third-party insurance providers. Each provider had a different API structure.

We used the Adapter Pattern to create a common interface and implemented separate adapters for each provider. The adapters transformed provider-specific responses into a standardized format, making the integration seamless.

**IInsuranceProviderAdapter** – Common interface.
**ProviderAAdapter** and **ProviderBAdapter** – Converted data into a unified InsurancePlan model.
**InsuranceAggregator** – Fetched data from all providers using DI in .NET Core.
This approach ensured scalability, flexibility, and maintainability.

#) How does the Adapter Pattern help in unit testing in .NET Core?
Answer:
✅ Dependency Injection (DI): Since adapters implement a common interface (IInsuranceProviderAdapter), we can mock them easily in unit tests.
✅ Decoupling from third-party services: We can test the business logic without calling actual third-party APIs.

#) How would you extend the Adapter Pattern if a new insurance provider needs to be added?
Answer:
Adding a new provider requires minimal changes:
1️⃣ Create a new service class for the provider (e.g., ProviderCService).
2️⃣ Implement an adapter (ProviderCAdapter) that transforms its response into a standard format.
3️⃣ Register the new adapter in Program.cs:
**builder.Services.AddTransient<IInsuranceProviderAdapter, ProviderCAdapter>();**
The InsuranceAggregator will automatically pick up the new provider without modifying existing code.
This follows the Open-Closed Principle (OCP) from SOLID.

#) How do you handle exceptions in the Adapter Pattern while integrating third-party APIs?
Answer:
When integrating third-party APIs, handling network failures, timeouts, and invalid responses is crucial.

🔹 Best Practices:
✅ Use try-catch blocks in the adapter to handle API failures.
✅ Implement policies using Polly for retry and circuit breaker mechanisms.

#)  How does the Adapter Pattern follow SOLID principles?
Answer:
✅ Single Responsibility Principle (SRP): Each adapter only handles one provider's API transformation.
✅ Open-Closed Principle (OCP): New providers can be added without modifying existing code.
✅ Liskov Substitution Principle (LSP): Any adapter can be replaced with another without breaking functionality.
✅ Interface Segregation Principle (ISP): The adapters implement only the required interface (IInsuranceProviderAdapter).
✅ Dependency Inversion Principle (DIP): The application depends on the abstraction (interface) rather than concrete classes.
