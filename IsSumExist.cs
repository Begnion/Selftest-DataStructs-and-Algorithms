        static bool IsSumExist(int[] nums, int count)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                var tmp = nums.ToList();
                tmp.RemoveAt(i);
                if (IsSumExist(tmp.ToArray(), num, count))
                    return true;
            }
            return false;
        }
        static bool IsSumExist(int[] nums, int sum, int count)
        {
            if (count > nums.Length)
                return false;
            else if (count == 1 && nums.Length > 0)
            {
                foreach (var num in nums)
                {
                    if (num == sum)
                        return true;
                }
                return false;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                var newSum = sum - num;
                var tmp = nums.ToList();
                tmp.RemoveAt(i);
                if (IsSumExist(tmp.ToArray(), newSum, count - 1))
                    return true;
            }
            return false;
        }