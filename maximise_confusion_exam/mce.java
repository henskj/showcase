class Solution {
    public int maxConsecutiveAnswers(String answerKey, int k) {
        int longest = 0;
        int point1 = 0;
        int point2 = 0;
        int cur = 0;
        int kRemaining = k;
        int fs = 0;
        int ts = 0;
        boolean skip = false;
        if (answerKey.length() == 1) {
            return 1;
        }

        while (point2 < answerKey.length()) {
            if (kRemaining > 0 || ts == fs) {
                if (answerKey.charAt(point2) == 'F') {
                    fs++;
                } else {ts++;}
                point2++;
                skip = true;
            } else if (fs != ts && kRemaining == 0) {
                    if (mostSymbols(fs,ts) && answerKey.charAt(point2) == 'T') {
                        skip = true;
                        point2++;
                        ts++;
                    } else if (!mostSymbols(fs,ts) && answerKey.charAt(point2) == 'F') {
                        skip = true;
                        point2++;
                        fs++;
                    } else {
                        skip = false;
                    }
            }
            if (kRemaining <= 0 && !skip) {
                if (answerKey.charAt(point1) == 'F') {
                    fs--;
                } else {
                    ts--;
                }
                point1++;
            }
            cur = fs+ts;
            kRemaining = k - Math.min(fs,ts);
            if (cur > longest) {
                longest = cur;
            }
        }
        return(longest);
    }
    public boolean mostSymbols(int fs, int ts) {
        //returns false if more symbols in current substring are false, else true
        return(fs > ts ? false : true);
    }
}
