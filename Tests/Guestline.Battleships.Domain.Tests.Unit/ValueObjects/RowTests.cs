using Guestline.Battleships.Domain.Exceptions;
using Guestline.Battleships.Domain.ValueObjects;

namespace Guestline.Battleships.Domain.Tests.Unit.ValueObjects
{
    public class RowTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalidInput")]
        [TestCase("G14")]
        [TestCase("A0")]
        public void ShouldThrowException_WhenInvalidInput(string input)
        {
            // ACT & ASSERT
            Assert.Throws<InvalidInputException>(() => Row.From(input));
        }

        [TestCase("A1", 1, 0)]
        [TestCase("B5", 5, 4)]
        [TestCase("C10", 10, 9)]
        public void ShouldReturnValidRow_WhenInputInRange(string input, int value, int iterableValue)
        {
            // ACT
            var row = Row.From(input);

            // ASSERT
            Assert.That(row.IterableValue, Is.EqualTo(iterableValue));
            Assert.That(row.Value, Is.EqualTo(value));
        }
    }
}
