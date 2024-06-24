using Assessments.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Assessments.Common;

namespace Assessments.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpiralMatrixGenerator _matrixGenerator;
        public ExerciseController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _matrixGenerator = new SpiralMatrixGenerator();
        }

        #region Exercise1  

        public IActionResult Exercise1()
        {
            return View(new AmountModel());
        }

        [HttpPost]
        public IActionResult Convert(AmountModel model)
        {
            ModelState.Remove("AmountInWords");

            if (ModelState.IsValid)
            {
                model.AmountInWords = ConvertAmountToWords(model.Amount);
                return View("Exercise1", model);
            }
            else
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Error in {state.Key}: {error.ErrorMessage}");
                    }
                }
            }
            return View("Exercise1", model);
        }

        private string ConvertAmountToWords(decimal amount)
        {
            string dollars = ((int)amount).ToWords();
            string cents = ((int)((amount - (int)amount) * 100)).ToString("00");

            return $"{dollars} and {cents}/100 dollars";
        }

        #endregion

        #region Exercise2
        public IActionResult Exercise2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Evaluate(string hand)
        {
            var cards = ParseHand(hand);
            var pokerHand = new Hand(cards);
            var rank = pokerHand.EvaluateHandRank();

            ViewBag.Hand = hand;
            ViewBag.Rank = rank;

            return View("Result");
        }

        private List<Card> ParseHand(string hand)
        {
            var cardStrings = hand.Split(' ');
            var cards = new List<Card>();

            foreach (var cardString in cardStrings)
            {
                var value = cardString.Substring(0, cardString.Length - 1);
                var suit = cardString.Last();
                cards.Add(new Card(value, suit));
            }

            return cards;
        }
        #endregion

        #region Exercise3
        public IActionResult Exercise3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Generate(int number)
        {
            var matrix = _matrixGenerator.GenerateSpiralMatrix(number);
            ViewBag.Matrix = matrix;
            return View("Exercise3");
        }

        #endregion
    }
}
