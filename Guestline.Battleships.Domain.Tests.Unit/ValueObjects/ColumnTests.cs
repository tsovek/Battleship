using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.ValueObjects;

namespace Guestline.Battleships.Domain.Tests.Unit.ValueObjects
{
    [TestFixture]
    public class ColumnTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidInput")]
        [TestCase("b9")]
        [TestCase("z8")]
        [TestCase("B")]
        public void ShouldThrowException_WhenInvalidInput(string input)
        {
            // ACT & ASSERT
            Assert.Throws<InvalidInputException>(() => Column.From(input));
        }

        [TestCase("A7", 'A', 0)]
        [TestCase("B1", 'B', 1)]
        public void ShouldReturnValidColumn_WhenValidInput(string input, char value, int iterableValue)
        {
            // Act & Assert
            var column = Column.From(input);

            Assert.That(column.Value, Is.EqualTo(value));
            Assert.That(column.IterableValue, Is.EqualTo(iterableValue));
        }
    }
}
