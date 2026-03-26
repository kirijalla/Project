using System;
using Final_Project_OOP.Exceptions;

namespace Final_Project_OOP.CoreClasses
{
    public class Package
    {
        public int Id { get; private set; }
        public double Weight { get; private set; }
        public int PriorityLevel { get; private set; }
        public string Destination { get; private set; }
        public string Status { get; private set; }

        public Package(int id, double weight, int priorityLevel, string destination, string status)
        {
            VerifyId(id);
            VerifyWeight(weight);
            VerifyPriorityLevel(priorityLevel);
            VerifyDestination(destination);
            VerifyStatus(status);

            Id = id;
            Weight = weight;
            PriorityLevel = priorityLevel;
            Destination = destination;
            Status = status;
        }

        private void VerifyId(int id)
        {
            if (id <= 0)
            {
                throw new InvalidPackageException("Invalid ID; ID must be greater than 0.");
            }
        }

        private void VerifyWeight(double weight)
        {
            if (weight <= 0)
            {
                throw new InvalidPackageException("Invalid weight; weight must be greater than 0.");
            }
        }

        private void VerifyPriorityLevel(int level)
        {
            if (level < 1 || level > 5)
            {
                throw new InvalidPackageException("Invalid level; must be between 1 and 5.");
            }
        }

        private void VerifyDestination(string destination)
        {
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new InvalidPackageException("Invalid destination; empty input.");
            }
        }

        private void VerifyStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new InvalidPackageException("Invalid status; empty status.");
            }

            if (status != "Pending" && status != "Assigned" && status != "Delivered")
            {
                throw new InvalidPackageException("Invalid status; status must be 'Pending', 'Assigned', or 'Delivered'.");
            }
        }

        public void UpdateStatus(string status)
        {
            if (status != "Pending" && status != "Assigned" && status != "Delivered")
            {
                throw new InvalidPackageException("Invalid status...");
            }

            Status = status;
        }

        public double CalculatePriorityScore(Package package)
        {
            int PriorityWeightFactor = 10;
            double score = (package.PriorityLevel * PriorityWeightFactor) - package.Weight;

            return score;
        }

        public bool IsHeavy(Package package)
        {
            if (package.Weight > 10)
            {
                return true;
            }
            return false;
        }
    }
}