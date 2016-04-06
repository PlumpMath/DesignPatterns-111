//Example Effective Java Second Edition Page 14
//Moved from Java to C#

using Helpers;

namespace Builder
{
    public class NutritionalFacts
    {
        //All Properties
        public int ServingSize { get; }
        public int Servings { get; }
        public int Calories { get; }
        public int Fat { get; }
        public int Sodium { get; }
        public int Carbohydrate { get; }

        public class Builder
        {
            //Required
            public int ServingSize { get; }
            public int Servings { get; }

            //Optionals
            public int Calories { get; private set; }
            public int Fat { get; private set; }
            public int Sodium { get; private set; }
            public int Carbohydrate { get; private set; }

            public Builder(int servingSize, int servings)
            {
                ServingSize = servingSize;
                Servings = servings;
            }

            public Builder SetCalories(int calories)
            {
                Calories = calories;
                return this;
            }

            public Builder SetFat(int fat)
            {
                Fat = fat;
                return this;
            }

            public Builder SetSodium(int sodium)
            {
                Sodium = sodium;
                return this;
            }

            public Builder SetCarbohydrate(int carbohydrate)
            {
                Carbohydrate = carbohydrate;
                return this;
            }

            public NutritionalFacts Build()
            {
                return new NutritionalFacts(this);
            }
        }

        private NutritionalFacts(Builder builder)
        {
            ServingSize = builder.ServingSize;
            Servings = builder.Servings;
            Calories = builder.Calories;
            Fat = builder.Fat;
            Sodium = builder.Sodium;
            Carbohydrate = builder.Carbohydrate;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var nutritionalFacts = new NutritionalFacts.Builder(10, 4)
                .SetCalories(100)
                .SetCarbohydrate(30)
                .SetFat(2)
                .Build();

            nutritionalFacts.Print();

            nutritionalFacts = new NutritionalFacts.Builder(14, 19).Build();
            nutritionalFacts.Print();
        }
    }
}
