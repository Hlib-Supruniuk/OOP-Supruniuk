using Xunit;

public class RepositoryTests
{
    private Customer CreateCustomer(int id = 1)
    {
        return new Customer(id, "Іван", "Петренко", "Рівне");
    }

    [Fact]
    public void Add_ShouldAddCustomer()
    {
        var repository = new InMemoryRepository<Customer>();
        var customer = CreateCustomer();

        repository.Add(customer);

        Assert.Equal(customer, repository.GetById(1));
    }

    [Fact]
    public void GetById_ShouldReturnCustomer()
    {
        var repository = new InMemoryRepository<Customer>();
        var customer = CreateCustomer();

        repository.Add(customer);

        Assert.Equal("Іван", repository.GetById(1)?.FirstName);
    }

    [Fact]
    public void GetById_ShouldReturnNull_WhenNotFound()
    {
        var repository = new InMemoryRepository<Customer>();

        Assert.Null(repository.GetById(100));
    }

    [Fact]
    public void GetAll_ShouldReturnAllCustomers()
    {
        var repository = new InMemoryRepository<Customer>();

        repository.Add(CreateCustomer(1));
        repository.Add(CreateCustomer(2));

        Assert.Equal(2, repository.GetAll().Count());
    }

    [Fact]
    public void Update_ShouldUpdateCustomer()
    {
        var repository = new InMemoryRepository<Customer>();
        repository.Add(CreateCustomer());

        var updatedCustomer = new Customer(
            1, "Олександр", "Іваненко", "Львів");

        repository.Update(updatedCustomer);

        Assert.Equal("Олександр", repository.GetById(1)?.FirstName);
    }

    [Fact]
    public void Update_ShouldThrow_WhenCustomerNotFound()
    {
        var repository = new InMemoryRepository<Customer>();

        Assert.Throws<InvalidOperationException>(
            () => repository.Update(CreateCustomer(100)));
    }

    [Fact]
    public void Delete_ShouldRemoveCustomer()
    {
        var repository = new InMemoryRepository<Customer>();
        repository.Add(CreateCustomer());

        repository.Delete(1);

        Assert.Null(repository.GetById(1));
    }

    [Fact]
    public void Delete_ShouldThrow_WhenCustomerNotFound()
    {
        var repository = new InMemoryRepository<Customer>();

        Assert.Throws<InvalidOperationException>(
            () => repository.Delete(100));
    }
}