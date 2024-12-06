namespace Day5;

public static class Input
{

    public static string inputTest = @$"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";

    public static string input = @"86|99
69|32
69|42
77|99
77|72
77|38
21|57
21|89
21|65
21|47
47|53
47|75
47|62
47|69
47|38
95|72
95|16
95|94
95|15
95|89
95|53
51|94
51|95
51|53
51|77
51|15
51|16
51|57
49|27
49|17
49|97
49|29
49|87
49|38
49|11
49|55
31|86
31|77
31|34
31|94
31|26
31|85
31|79
31|36
31|57
94|77
94|91
94|99
94|62
94|53
94|61
94|56
94|69
94|26
94|83
35|94
35|99
35|91
35|29
35|97
35|89
35|49
35|56
35|47
35|86
35|27
53|62
53|42
53|69
53|76
53|59
53|27
53|49
53|72
53|11
53|89
53|26
53|91
24|94
24|95
24|15
24|47
24|64
24|65
24|91
24|35
24|49
24|16
24|75
24|51
24|89
75|32
75|91
75|42
75|99
75|11
75|62
75|97
75|72
75|83
75|59
75|53
75|56
75|27
75|29
89|73
89|62
89|97
89|99
89|83
89|38
89|56
89|15
89|29
89|87
89|55
89|27
89|76
89|11
89|17
87|33
87|11
87|57
87|34
87|51
87|95
87|45
87|36
87|31
87|64
87|98
87|35
87|85
87|55
87|21
87|32
45|75
45|86
45|16
45|57
45|72
45|99
45|49
45|53
45|64
45|51
45|26
45|15
45|95
45|77
45|69
45|59
45|89
42|27
42|62
42|17
42|79
42|31
42|34
42|36
42|98
42|56
42|32
42|24
42|11
42|85
42|87
42|97
42|55
42|83
42|76
29|17
29|87
29|55
29|73
29|76
29|11
29|27
29|61
29|45
29|79
29|36
29|85
29|62
29|83
29|25
29|97
29|32
29|24
29|98
57|91
57|15
57|16
57|42
57|72
57|38
57|89
57|65
57|99
57|69
57|53
57|26
57|59
57|49
57|97
57|94
57|64
57|35
57|56
57|29
33|24
33|57
33|21
33|94
33|64
33|77
33|75
33|16
33|79
33|34
33|51
33|47
33|86
33|65
33|26
33|36
33|95
33|49
33|91
33|45
33|35
79|24
79|64
79|45
79|26
79|85
79|72
79|65
79|94
79|75
79|16
79|35
79|34
79|57
79|91
79|49
79|86
79|36
79|53
79|95
79|51
79|47
79|77
26|49
26|42
26|25
26|62
26|73
26|69
26|99
26|65
26|97
26|59
26|87
26|32
26|11
26|38
26|29
26|27
26|15
26|83
26|89
26|76
26|98
26|56
26|61
99|42
99|56
99|97
99|79
99|25
99|59
99|76
99|38
99|36
99|55
99|17
99|98
99|61
99|11
99|73
99|24
99|62
99|32
99|33
99|27
99|87
99|83
99|31
99|29
83|57
83|36
83|98
83|33
83|95
83|45
83|62
83|31
83|25
83|51
83|85
83|11
83|24
83|34
83|27
83|73
83|61
83|21
83|87
83|32
83|55
83|17
83|79
83|76
11|98
11|57
11|45
11|25
11|79
11|94
11|55
11|34
11|73
11|21
11|24
11|35
11|47
11|51
11|16
11|95
11|77
11|85
11|86
11|64
11|17
11|31
11|33
11|36
15|62
15|29
15|59
15|11
15|36
15|27
15|33
15|73
15|83
15|79
15|56
15|76
15|25
15|31
15|17
15|98
15|38
15|61
15|42
15|32
15|99
15|97
15|55
15|87
64|49
64|53
64|94
64|26
64|91
64|42
64|16
64|83
64|15
64|69
64|86
64|97
64|47
64|99
64|72
64|59
64|89
64|65
64|77
64|56
64|75
64|35
64|29
64|38
38|79
38|85
38|36
38|25
38|21
38|34
38|24
38|55
38|83
38|45
38|73
38|33
38|61
38|51
38|76
38|32
38|98
38|62
38|31
38|95
38|17
38|27
38|11
38|87
16|94
16|97
16|53
16|59
16|75
16|56
16|27
16|72
16|91
16|62
16|38
16|87
16|26
16|29
16|77
16|49
16|42
16|15
16|86
16|69
16|99
16|65
16|83
16|89
55|57
55|72
55|77
55|85
55|79
55|26
55|24
55|75
55|64
55|65
55|45
55|86
55|94
55|35
55|34
55|51
55|16
55|91
55|33
55|36
55|53
55|95
55|47
55|21
76|85
76|25
76|79
76|73
76|36
76|94
76|33
76|57
76|16
76|31
76|35
76|45
76|34
76|47
76|64
76|32
76|55
76|24
76|17
76|95
76|51
76|11
76|21
76|98
56|62
56|97
56|98
56|45
56|24
56|38
56|73
56|17
56|79
56|85
56|25
56|36
56|33
56|61
56|11
56|32
56|34
56|76
56|83
56|31
56|87
56|55
56|27
56|21
98|79
98|35
98|51
98|33
98|45
98|95
98|25
98|75
98|57
98|31
98|24
98|17
98|21
98|16
98|77
98|55
98|85
98|64
98|34
98|86
98|53
98|47
98|94
98|36
25|85
25|36
25|79
25|51
25|53
25|55
25|24
25|21
25|64
25|33
25|16
25|95
25|57
25|86
25|31
25|47
25|45
25|34
25|35
25|77
25|17
25|94
25|91
25|75
27|61
27|85
27|45
27|87
27|21
27|73
27|79
27|33
27|55
27|62
27|17
27|24
27|76
27|11
27|98
27|32
27|95
27|31
27|51
27|25
27|34
27|57
27|64
27|36
73|57
73|24
73|85
73|77
73|94
73|25
73|35
73|16
73|34
73|36
73|98
73|51
73|86
73|64
73|21
73|75
73|33
73|31
73|79
73|95
73|47
73|45
73|17
73|55
62|79
62|24
62|87
62|76
62|61
62|45
62|57
62|36
62|33
62|25
62|17
62|21
62|64
62|31
62|32
62|55
62|73
62|35
62|85
62|95
62|11
62|98
62|34
62|51
17|79
17|57
17|16
17|47
17|53
17|26
17|91
17|51
17|94
17|77
17|31
17|21
17|75
17|24
17|86
17|95
17|85
17|36
17|55
17|34
17|33
17|45
17|64
17|35
36|51
36|77
36|95
36|47
36|35
36|65
36|64
36|53
36|91
36|45
36|24
36|72
36|26
36|86
36|21
36|69
36|75
36|34
36|94
36|89
36|49
36|57
36|85
36|16
61|31
61|32
61|35
61|24
61|95
61|98
61|79
61|76
61|17
61|47
61|21
61|33
61|34
61|16
61|45
61|73
61|11
61|51
61|25
61|57
61|85
61|64
61|36
61|55
72|59
72|83
72|76
72|97
72|38
72|42
72|31
72|11
72|87
72|89
72|25
72|98
72|99
72|27
72|56
72|32
72|29
72|17
72|62
72|49
72|73
72|61
72|15
72|69
91|26
91|99
91|72
91|73
91|56
91|27
91|11
91|15
91|98
91|59
91|89
91|49
91|83
91|42
91|97
91|65
91|32
91|87
91|76
91|29
91|38
91|61
91|69
91|62
59|76
59|98
59|97
59|38
59|56
59|83
59|31
59|79
59|24
59|27
59|32
59|62
59|85
59|61
59|87
59|55
59|17
59|36
59|33
59|73
59|42
59|29
59|25
59|11
34|91
34|59
34|47
34|89
34|72
34|99
34|65
34|69
34|75
34|86
34|95
34|26
34|57
34|77
34|51
34|15
34|35
34|29
34|94
34|64
34|49
34|53
34|21
34|16
65|49
65|56
65|32
65|72
65|69
65|97
65|83
65|25
65|98
65|27
65|62
65|29
65|73
65|38
65|59
65|99
65|89
65|61
65|87
65|17
65|76
65|42
65|15
65|11
32|55
32|35
32|57
32|16
32|45
32|94
32|73
32|79
32|34
32|17
32|77
32|98
32|64
32|36
32|95
32|85
32|51
32|47
32|24
32|25
32|11
32|31
32|33
32|21
85|21
85|26
85|47
85|64
85|65
85|49
85|95
85|57
85|45
85|89
85|16
85|35
85|51
85|15
85|99
85|86
85|72
85|53
85|91
85|69
85|75
85|34
85|94
85|77
97|98
97|73
97|21
97|24
97|36
97|61
97|87
97|31
97|33
97|38
97|11
97|62
97|32
97|25
97|17
97|85
97|27
97|34
97|55
97|83
97|51
97|45
97|76
97|79
86|38
86|27
86|76
86|56
86|87
86|59
86|65
86|69
86|32
86|61
86|15
86|42
86|72
86|89
86|26
86|62
86|83
86|97
86|53
86|29
86|49
86|91
86|75
69|59
69|83
69|29
69|38
69|76
69|61
69|87
69|25
69|99
69|55
69|62
69|17
69|27
69|73
69|11
69|89
69|56
69|15
69|98
69|97
69|33
69|31
77|27
77|26
77|42
77|86
77|97
77|49
77|62
77|65
77|89
77|15
77|87
77|59
77|76
77|56
77|53
77|61
77|69
77|91
77|75
77|83
77|29
21|94
21|69
21|42
21|86
21|95
21|59
21|77
21|51
21|99
21|35
21|15
21|64
21|75
21|29
21|26
21|49
21|16
21|91
21|72
21|53
47|42
47|94
47|86
47|59
47|77
47|97
47|29
47|15
47|83
47|72
47|99
47|26
47|16
47|27
47|56
47|91
47|89
47|49
47|65
95|97
95|35
95|42
95|99
95|86
95|59
95|77
95|69
95|29
95|57
95|64
95|47
95|49
95|91
95|56
95|75
95|65
95|26
51|47
51|75
51|65
51|89
51|91
51|86
51|59
51|35
51|29
51|99
51|42
51|26
51|64
51|69
51|72
51|49
51|56
49|42
49|25
49|99
49|73
49|59
49|61
49|15
49|62
49|32
49|69
49|76
49|89
49|98
49|83
49|31
49|56
31|47
31|75
31|35
31|45
31|64
31|24
31|16
31|33
31|91
31|21
31|53
31|51
31|55
31|65
31|95
94|86
94|42
94|97
94|59
94|49
94|15
94|27
94|72
94|38
94|89
94|75
94|87
94|65
94|29
35|15
35|38
35|75
35|65
35|72
35|69
35|83
35|59
35|26
35|16
35|53
35|77
35|42
53|15
53|83
53|87
53|99
53|73
53|65
53|97
53|29
53|61
53|38
53|32
53|56
24|69
24|77
24|34
24|26
24|85
24|57
24|21
24|72
24|45
24|53
24|86
75|76
75|65
75|89
75|87
75|49
75|69
75|38
75|26
75|15
75|61
89|98
89|33
89|59
89|79
89|25
89|61
89|31
89|32
89|42
87|73
87|24
87|79
87|17
87|61
87|47
87|25
87|76
45|21
45|91
45|47
45|35
45|34
45|65
45|94
42|33
42|73
42|61
42|45
42|25
42|38
29|33
29|38
29|56
29|31
29|42
57|86
57|77
57|47
57|75
33|72
33|85
33|53
79|69
79|21
26|72

69,32,62,98,65,72,59,15,56,89,87
64,35,16,77,86,75,91,26,49,69,89,15,99,59,29,42,56,97,38
26,53,16,35,49,99,86,69,89,15,77,83,42,56,72,47,94,65,59,38,75,29,91
69,98,87,89,73,38,15,76,62,11,61,55,42,83,29,97,99,56,31
47,16,75,91,26,89,97,38,27
47,16,95,55,11,51,34,24,94,79,35,45,57,32,73
33,24,16,31,47,21,73,36,57,86,94
33,79,45,75,95,17,51,94,36,34,25,47,24,55,16,53,86,57,85
27,79,62,98,36
79,36,75,98,21,85,47,33,16
55,31,57,95,35,33,25,47,79,34,21,64,24,36,98,61,11,45,32,76,17
32,27,38,99,89,25,31,61,55,33,56,29,59
16,53,72,49,42,15,97,56,86,26,65,91,69,38,89,64,47
25,17,31,55,33,24,85,45,21,51,95,57,64,35,94,77,86,75,53
49,56,11,87,42,32,99,29,72,38,89,97,61,65,83,25,15,98,73,69,62,76,59
95,85,86,15,53,21,89
45,75,24,94,25,51,85,36,55,47,35,95,33,53,34
57,21,86,16,85
73,79,95,86,21,24,33,34,17,25,64
33,11,31,64,25,17,73,36,21,76,51,34,57,45,98,47,95,16,32
98,25,33,34,95,77,75
51,94,64,95,34,21,35,53,86,24,79
47,16,94,77,86,53,91,26,65,72,89,15,99,59,29,42,56,97,38,83,27
32,99,26,59,65,87,49,29,91,62,56,27,61,75,69,97,72
83,98,62,24,79,76,97,55,85,38,45
49,89,15,29,42,38,62,87,61,76,11,73,31
64,34,49,77,26,65,91,35,59,15,99,16,69,53,51,72,89,47,86
98,17,79,85,95,16,75
59,21,86,99,57,15,29,49,47
73,85,98,76,24,33,32,27,29
45,21,86,75,69
83,97,45,55,76,56,33,42,36,38,25,17,62
77,79,51,72,16,95,57,85,36,64,47,65,75,33,91,21,26
72,26,34,47,59,89,64,95,57,53,94,21,49
53,91,26,72,49,69,89,15,99,59,29,56,97,38,83,27,62,87,61,32,11
35,57,91,26,45,53,99,51,34,77,94,69,65,15,86,75,89,95,16
35,16,77,86,75,91,72,69,59,29,56,38,83
26,49,89,99,59,29,42,56,83,27,87,61,76,32,11,73,98
73,98,25,17,55,33,79,24,85,45,34,51,95,35,47,94,86
69,89,15,99,59,29,42,56,97,38,83,27,62,61,76,32,11,73,98,25,17,31,55
76,56,87,55,61,59,11,79,17,27,73
97,38,83,27,87,61,76,73,17,31,55,36,45,34,21
38,83,27,62,87,61,76,32,11,73,98,17,31,55,33,79,36,24,85,45,34,21,51
76,55,33,79,24,45,95,64,16
29,56,38,83,27,76,11,73,25,36,85
53,91,26,65,72,49,69,89,15,99,59,29,42,97,38,83,27,62,87,61,76,32,11
35,75,64,36,79,31,25,33,17
49,76,56,69,32,31,59
95,35,16,86,53,26,65,99,42
94,77,86,75,26,65,72,49,69,89,29,42,56,83,27,62,87
98,21,16,77,57,95,45,34,94,33,79
95,57,64,16,53,72,49,89,15,59,56
57,64,47,16,77,86,53,49,15,99,59
76,32,11,73,98,25,17,31,55,33,79,36,24,85,45,34,51,95,57,64,35,47,16
75,72,56,65,42,59,69,53,27,26,61,97,76,87,99,91,49,89,83,15,38
59,56,97,38,27,61,76,11,98,17,31,33,79,36,24
57,64,35,47,16,94,77,86,75,53,91,26,65,72,49,69,89,15,99,59,42,56,97
15,83,89,69,99,38,97,29,73,62,27,72,91,76,65
85,31,21,16,36,33,98,35,55,34,94,75,47,17,79,45,95,51,57,86,77
57,72,16,99,51,94,89,45,53
11,87,59,31,62,42,97,36,55,38,33,73,83,56,27,32,98,17,99
34,25,47,98,79,85,95,55,24,86,94,45,33,77,17,21,31,57,35,51,36,75,64
29,56,38,83,62,61,76,32,98,25,17,31,55,33,79,24,85
87,61,32,11,73,98,25,17,31,55,33,36,24,85,45,34,21,51,95
31,33,79,24,34,16,94,91,26
79,34,91,33,16,47,26,35,24,45,75,77,31,64,51,95,86,21,57,55,94
64,75,51,36,85,57,91
89,15,56,97,38,83,62,87,76,32,73,25,31,55,33
34,21,51,57,64,35,77,86,53,91,26,65,72,89,59
83,62,87,61,32,17,24,85,45,21,95
35,47,16,77,86,75,26,65,72,49,42,38,83
33,83,31,56,98,15,59,17,79,97,61,76,62,42,32
32,11,61,87,62,55,98,15,59,29,42,31,76,38,56,83,97
61,49,15,42,87,72,53,76,27,29,38,62,65,59,75,26,83,56,91,86,89,69,99
45,31,76,79,85,83,25,95,27,51,17,98,11,32,24
53,59,27,87,32
87,32,11,73,98,17,31,36,21,57,35
65,72,49,69,89,15,99,59,29,42,56,87,61,11,73
86,75,53,89,15,42,83,62,61
38,24,83,73,32,34,87,11,79,33,36,25,27,98,45,85,31,21,55,61,17
17,56,85,34,55,83,27,62,87,61,11,76,32,31,73,79,45,98,97,38,36,33,25
47,16,26,65,69,29,27
77,72,65,47,64,57,91,75,24,95,89,16,94,21,53,26,69
91,15,57,77,72,64,16,65,95,86,53,42,89,59,99,69,47
31,55,33,79,36,45,34,21,51,95,47,94,86,53,26
64,24,75,35,25,16,36,95,85,47,55,53,77,31,33,57,17
64,51,79,36,25,76,62,98,45
62,61,56,36,55,17,33,31,87,79,32,98,25,73,45,38,76
99,53,65,97,72,47,29,57,42,86,15,59,16
77,59,49,38,42,26,69,65,56,27,89,29,15,53,86,91,61,87,62
83,31,15,17,11,69,55,89,56,59,27
49,69,89,15,99,59,29,42,56,97,27,62,87,61,76,11,73,98,25
42,56,27,11,98,24,45
57,64,35,47,16,77,86,75,53,91,26,65,72,49,69,89,99,59,29,56,97
75,53,91,26,15,42,56,87,32
69,89,15,99,59,29,56,83,27,62,76,73,55
72,49,69,89,15,99,59,42,56,38,83,27,87,61,76,32,11,73,98,25,17
38,24,17,79,85,61,98,11,73,25,45,87,33,56,32,55,31,76,62,83,27,36,42
77,86,75,53,65,72,89,15,42,56,38,83,27,62,61
11,73,98,25,31,79,85,34,21,51,57,64,35,47,77
31,85,45,21,47
42,15,49,38,87,62,76,61,97,73,83,27,31,17,29,89,56
99,72,49,16,15,91,47,89,69
33,79,87,61,76,11,55,45,25,34,98,32,83,51,85,38,31
75,72,26,15,83,62,56,16,29,97,59,94,69,65,27,86,77,99,53,42,91,49,89
33,45,51,57,77,53,91
29,83,27,87,32,11,73,98,31,55,33
73,98,25,17,55,33,79,36,24,85,45,34,21,51,95,64,47,16,86
83,76,17,24,85,34,95
95,57,35,47,16,94,77,75,53,91,26,65,72,49,89,15,99,59,29,42,56
61,72,38,76,42,99,49,91,73
75,87,86,69,59,89,53,27,94,42,56,99,29,26,62,83,77,91,38
31,94,16,77,36,33,35,55,51,47,45,64,17,91,53,95,57,86,75
64,35,47,16,94,77,86,75,53,91,26,65,72,49,69,89,59,29,56,97,38
35,94,86,75,91,26,65,15,99,59,56,97,83
98,25,57,21,62,61,55,87,51,85,24,45,76
16,53,65,69,89,15,99,27,62
51,95,57,64,35,16,86,75,91,65,72,29,42
57,86,75,29,42,56,97
95,64,98,47,51,76,31,11,32,55,34,17,36,24,35,45,57,21,79,61,85,73,25
95,57,64,35,47,94,86,75,53,91,26,65,72,69,15,99,59,42,56
64,17,45,24,85,94,55,95,21,32,73,79,34,31,11
36,24,85,45,34,51,95,57,64,35,47,16,94,77,86,75,53,91,26,65,72,49,69
53,49,26,72,27,56,16,29,47,69,83,89,97,42,86,91,65,15,99
32,29,76,42,59,38,98,25,65,11,87
53,26,64,47,16,65,51,49,57,21,59,72,99,91,34,77,86
31,55,79,36,24,85,45,34,95,64,35,16,77,75,91
69,85,51,94,57,72,47,15,77,45,65
94,27,65,75,97,89,99,42,69,83,15,26,16,49,59,29,62
32,11,73,98,31,55,79,36,24,34,21,57,64,16,94
34,51,95,57,64,35,47,16,94,77,86,75,53,91,26,65,72,49,69,89,15,99,59
64,47,16,94,77,75,53,91,65,72,49,89,15,59,29,42,56,97,38
33,79,36,24,85,45,21,51,95,64,35,47,16,94,77,86,75,91,26,65,72
72,75,77,65,64,21,57,95,51,33,26
11,25,17,45,34,57,77
24,85,34,95,57,64,47,77,86,75,91,69,89
11,98,25,17,55,36,24,45,34,95,47,16,77
77,86,75,53,26,65,49,69,89,99,59,29,42,56,97,38,83,87,61
73,98,17,31,55,33,36,24,85,45,34,51,95,64,35,47,16,94,86
85,72,36,26,95,69,75,77,57
65,42,16,26,94,72,89,64,35,69,57,56,47,53,91,15,77,75,59,99,97,29,86
34,25,73,32,62,27,97,85,11,61,98,31,38,87,17,24,36,55,21
89,59,29,56,97,32,17,55,33
75,21,26,55,77,85,33,64,51,36,95,16,45,53,35,65,34,47,57,91,94,86,24
62,87,32,11,73,31,55,79,36,45,34,51,64
72,89,99,56,32,25,17
25,55,33,36,45,51,35
45,34,21,51,64,47,94,77,86,75,53,91,65,72,49,89,99
75,76,53,61,62,89,59,32,26
76,61,79,62,73,97,55,27,33,25,34,24,85
76,11,73,25,17,55,33,79,85,45,34,21,51,95,57,64,16
61,56,17,11,31,59,42,55,32,27,38,97,15,29,33,98,25,89,73,62,99,83,76
55,36,85,45,77,86,53
36,73,97,42,27,83,99,79,38,55,59,87,62,25,98,32,29,31,61,11,76
83,25,62,45,36,24,73,17,55,42,38,32,31,61,76,97,98,11,87,79,33
25,17,31,33,79,36,24,85,45,34,21,51,95,57,64,35,47,16,94,77,86,75,53
79,85,95,64,94,75,91,26,49
36,85,34,95,64,35,77,86,75,53,91,26,65,72,69
91,35,26,51,21,49,34,69,86,85,45,64,95,89,65,75,15,57,47,53,94
91,26,65,72,49,69,89,15,99,59,29,42,56,97,38,83,27,62,87,61,76,32,11
33,31,32,25,36,51,47,11,45,64,98,57,35,76,61
25,45,73,51,85,36,57,86,21,31,34,98,64,47,95
72,49,69,89,15,99,59,29,42,56,97,38,83,27,62,87,61,76,32,11,73,98,17
75,53,91,26,65,72,69,89,15,99,59,29,56,97,38,83,62,87,61,76,32
53,91,26,65,49,69,89,15,99,59,29,56,97,38,83,62,61,76,32
17,33,79,24,34,21,57,53,91
15,42,25,17,73,79,99,87,62
32,73,25,24,35,47,94
49,69,89,15,99,29,42,56,38,83,27,62,87,61,76,11,73,98,25,17,31
85,45,34,21,51,57,64,35,47,16,94,77,75,91,26,65,72,49,15
94,99,89,45,72,26,34
42,32,83,61,27,31,29,55,56,79,17,11,15,25,97
21,51,95,57,64,35,47,16,94,77,75,53,91,26,72,69,89,59,29
87,76,32,11,73,98,25,17,31,55,33,79,36,24,85,45,34,21,51,95,57,64,35
79,36,24,85,45,34,21,51,95,64,47,16,94,77,75,72,49
34,24,76,64,33,62,85,45,95,73,17,79,25,36,61
72,49,42,83,62,61,76,11,73,98,17
42,15,91,59,65,95,35,94,47,57,56,53,75,72,26
95,11,61,73,55,51,76,35,57,17,21,33,98,85,32,36,34,25,64
97,83,61,32,11,73,98,25,17,31,55,33,79,36,85,34,21
85,21,51,95,16,94,77,91,26,65,49,89,15
72,29,32,69,49,83,89,15,42,27,65";
}