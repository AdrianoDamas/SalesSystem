using System;

namespace Sales.Domain.SalesAggregate
{
    public class InvalidAgeExceptions : ArgumentException
    {
        public InvalidAgeExceptions(): base("Sales cannot be that old.")
        {
        }
    }
}
