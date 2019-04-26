Plan

Similar to Boggle

Need:
- Main Menu
- Game Screen
- Scoring Page
- Leaderboard

Technical:
- character selected, don't reset on release, reset on submission
- enumerate solutions from a board
- lock to load words into dictionary
- saving file data

Extras:
- more modes
- user interface
- accounts

Sun, Mar 31:
- save mechanics
- path formation drag + click
- (release is a submit)

A4 solutions

Q1:
- some basic properties hold
- inductive hypothesis
- holds generally if base case and IH
 e -> and receive (m) -> e' -> and receive (m)
LC1:
LC2:

Q2:
(x)				(y)
site1			site2
Ti { Ri(x)
   { Wi(x)
Tj { Rj(x)		Ri(y) } Ti
   { Wj(x)		Wi(y) }
				Rj(y) } Tj
				Wj(y) }

serializability?
All operations of i happen before j. Ti happen before Tj.
conflict equivalent?
yes?
2 phase lock?
Tj can't start until Ti commits. Can't do 2 phase locking.

timestamp ordering gives you serial ordering
Ti = T1, Tj = T2

x				y
wts, rts 1		wts, rts 1
wts, wts 2		wts, rts 2

Q5:
1. coordinator fails
- voting phase
- abort
- look at log
- send all participants abort

2. participant fails after receiving prepare
- look in log no global decision
- recover ask coordinator
- ask coordinator, if it broadcast decision
- coordinator failed, then same as 1. abort

Q3:
Design a quorum system
S1, S2, S3
C is attached locally to S1
Vr + Vw > V
Vw > V / 2

V = 3, s1=1, s2 =1, s3=1
Vw=2, Vr = 2

Soln
V = 4, s1 = 1, s2 = 1, s3=2
Vw= 3, Vr = 2
2 + 3 > 4
2 > 1.5

