namespace Api.Dtos {
    public class StudentDashBoardDto {
        public double CanteenBalance { get; set; }
        public int NumberOfBooksCurrentlyBorrowed { get; set; }
        public int AccumulatedPenalty { get; set; }
    }
}