namespace Assessments.Models
{
    public class SpiralMatrixGenerator
    {
        public int[,] GenerateSpiralMatrix(int n)
        {
            int size = (int)Math.Ceiling(Math.Sqrt(n + 1));
            int[,] matrix = new int[size, size];
            int value = n;
            int minRow = 0, maxRow = size - 1;
            int minCol = 0, maxCol = size - 1;

            while (value >= 0)
            {
                for (int i = minCol; i <= maxCol && value >= 0; i++) matrix[minRow, i] = value--;
                minRow++;
                for (int i = minRow; i <= maxRow && value >= 0; i++) matrix[i, maxCol] = value--;
                maxCol--;
                for (int i = maxCol; i >= minCol && value >= 0; i--) matrix[maxRow, i] = value--;
                maxRow--;
                for (int i = maxRow; i >= minRow && value >= 0; i--) matrix[i, minCol] = value--;
                minCol++;
            }

            return matrix;
        }
    }
}
