using System;
using Final_Project_OOP.Exceptions;

namespace Final_Project_OOP.CoreClasses
{
    public class Package
    {

        private int id;
        private double weight;
        private int priorityLevel;
        private string destination;
        private string status;

        public void SetId(int id)
        {
            this.id = id;
        }
        public int GetID()
        {
            return id;
        }
        public void SetWeight(double weight)
        {
            this.weight = weight;
        }
        public double GetWeight()
        {
            return weight;
        }
        public void SetPriorityLevel(int priorityLevel)
        {
            this.priorityLevel = priorityLevel;
        }
        public int GetPriorityLevel()
        {
            return priorityLevel;
        }
        public void SetDestination(string destination)
        {
            this.destination = destination;
        }
        public string GetDestination()
        {
            return destination;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
        public string GetStatus() { return status; }

        public Package(int id, double weight, int priorityLevel, string destination, string status)
        {
            // Validate inputs

            VerifyId(id);
            VerifyWeight(weight);
            VerifyPriorityLevel(priorityLevel);
            VerifyDestination(destination);
            VerifyStatus(status);

            // Create object

            SetId(id);
            SetWeight(weight);
            SetPriorityLevel(priorityLevel);
            SetDestination(destination);
            SetStatus(status);
        }

        // Input validations 

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

            SetStatus(status);
        }

        public double CalculatePriorityScore(Package package)
        {
            int PriorityWeightFactor = 10;
            double score = (package.GetPriorityLevel() * PriorityWeightFactor) - package.GetWeight();

            return score;
        }

        public bool IsHeavy(Package package)
        {
            if (package.GetWeight() > 10)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"ID: {id} - Weight: {weight} - Priority Level: {priorityLevel} - Destination: {destination} - Status: {status}";
        }
    }
}