using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	public GameObject y0Prefab;
	public GameObject y1Prefab;
	public GameObject y2Prefab;
	public GameObject y3Prefab;
	public GameObject y4Prefab;
	public GameObject y5Prefab;
	public GameObject y6Prefab;
	public GameObject y7Prefab;
	public GameObject y8Prefab;
	public GameObject y9Prefab;
	public GameObject b0Prefab;
	public GameObject b1Prefab;
	public GameObject b2Prefab;
	public GameObject b3Prefab;
	public GameObject b4Prefab;
	public GameObject b5Prefab;
	public GameObject b6Prefab;
	public GameObject b7Prefab;
	public GameObject b8Prefab;
	public GameObject b9Prefab;
	public GameObject g0Prefab;
	public GameObject g1Prefab;
	public GameObject g2Prefab;
	public GameObject g3Prefab;
	public GameObject g4Prefab;
	public GameObject g5Prefab;
	public GameObject g6Prefab;
	public GameObject g7Prefab;
	public GameObject g8Prefab;
	public GameObject g9Prefab;
	public GameObject r0Prefab;
	public GameObject r1Prefab;
	public GameObject r2Prefab;
	public GameObject r3Prefab;
	public GameObject r4Prefab;
	public GameObject r5Prefab;
	public GameObject r6Prefab;
	public GameObject r7Prefab;
	public GameObject r8Prefab;
	public GameObject r9Prefab;

	int y0 = 2;
	int y1 = 2;
	int y2 = 2;
	int y3 = 2;
	int y4 = 2;
	int y5 = 2;
	int y6 = 2;
	int y7 = 2;
	int y8 = 2;
	int y9 = 2;
	int b0 = 2;
	int b1 = 2;
	int b2 = 2;
	int b3 = 2;
	int b4 = 2;
	int b5 = 2;
	int b6 = 2;
	int b7 = 2;
	int b8 = 2;
	int b9 = 2;
	int g0 = 2;
	int g1 = 2;
	int g2 = 2;
	int g3 = 2;
	int g4 = 2;
	int g5 = 2;
	int g6 = 2;
	int g7 = 2;
	int g8 = 2;
	int g9 = 2;
	int r0 = 2;
	int r1 = 2;
	int r2 = 2;
	int r3 = 2;
	int r4 = 2;
	int r5 = 2;
	int r6 = 2;
	int r7 = 2;
	int r8 = 2;
	int r9 = 2;

	int X = 410;
	int Y = 300;
	int Z = 13;
	int X2 = 410;
	int Y2 = 540;
	int Z2 = 13;
	int X3 = 500;
	int Y3 = 420;
	int Z3 = 13;

	int p = 0;
	int q = 0;

	int t = 0;

	int i = 0;

	int color;
	int colormin = 0;
	int colormax = 4;

	int number;
	int numbermin = 0;
	int numbermax = 10;



	public void Deal(){
		

		while (p < 3) {
			while (i < 7) {

				color = UnityEngine.Random.Range (colormin, colormax);
				number = UnityEngine.Random.Range (numbermin, numbermax);
	

				if (color == 0 && number == 0) {
					if (y0 > 0) {
						if (t == 0) {
							Instantiate (y0Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y0 -= 1;
						}
						if (t == 1) {
							Instantiate (y0Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y0 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 1) {
					if (y1 > 0) {
						if (t == 0) {
							Instantiate (y1Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y1 -= 1;
						}
						if (t == 1) {
							Instantiate (y1Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y1 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 2) {
					if (y2 > 0) {
						if (t == 0) {
							Instantiate (y2Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y2 -= 1;
						}
						if (t == 1) {
							Instantiate (y2Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y2 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 3) {
					if (y3 > 0) {
						if (t == 0) {
							Instantiate (y3Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y3 -= 1;
						}
						if (t == 1) {
							Instantiate (y3Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y3 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 4) {
					if (y4 > 0) {
						if (t == 0) {
							Instantiate (y4Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y4 -= 1;
						}
						if (t == 1) {
							Instantiate (y4Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y4 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 5) {
					if (y5 > 0) {
						if (t == 0) {
							Instantiate (y5Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y5 -= 1;
						}
						if (t == 1) {
							Instantiate (y5Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y5 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 6) {
					if (y6 > 0) {
						if (t == 0) {
							Instantiate (y6Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y6 -= 1;
						}
						if (t == 1) {
							Instantiate (y6Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y6 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 7) {
					if (y7 > 0) {
						if (t == 0) {
							Instantiate (y7Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y7 -= 1;
						}
						if (t == 1) {
							Instantiate (y7Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y7 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 8) {
					if (y8 > 0) {
						if (t == 0) {
							Instantiate (y8Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y8 -= 1;
						}
						if (t == 1) {
							Instantiate (y8Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y8 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 0 && number == 9) {
					if (y9 > 0) {
						if (t == 0) {
							Instantiate (y9Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							y9 -= 1;
						}
						if (t == 1) {
							Instantiate (y9Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							y9 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 0) {
					if (b0 > 0) {
						if (t == 0) {
							Instantiate (b0Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b0 -= 1;
						}
						if (t == 1) {
							Instantiate (b0Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b0 -= 1;
						}
					} else {
						i -= 1;
					}
					;
				}
				if (color == 1 && number == 1) {
					if (b1 > 0) {
						if (t == 0) {
							Instantiate (b1Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b1 -= 1;
						}
						if (t == 1) {
							Instantiate (b1Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b1 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 2) {
					if (b2 > 0) {
						if (t == 0) {
							Instantiate (b2Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b2 -= 1;
						}
						if (t == 1) {
							Instantiate (b2Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b2 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 3) {
					if (b3 > 0) {
						if (t == 0) {
							Instantiate (b3Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b3 -= 1;
						}
						if (t == 1) {
							Instantiate (b3Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b3 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 4) {
					if (b4 > 0) {
						if (t == 0) {
							Instantiate (b4Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b4 -= 1;
						}
						if (t == 1) {
							Instantiate (b4Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b4 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 5) {
					if (b5 > 0) {
						if (t == 0) {
							Instantiate (b5Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b5 -= 1;
						}
						if (t == 1) {
							Instantiate (b5Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b5 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 6) {
					if (b6 > 0) {
						if (t == 0) {
							Instantiate (b6Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b6 -= 1;
						}
						if (t == 1) {
							Instantiate (b6Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b6 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 7) {
					if (b7 > 0) {
						if (t == 0) {
							Instantiate (b7Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b7 -= 1;
						}
						if (t == 1) {
							Instantiate (b7Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b7 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 8) {
					if (b8 > 0) {
						if (t == 0) {
							Instantiate (b8Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b8 -= 1;
						}
						if (t == 1) {
							Instantiate (b8Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b8 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 1 && number == 9) {
					if (b9 > 0) {
						if (t == 0) {
							Instantiate (b9Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							b9 -= 1;
						}
						if (t == 1) {
							Instantiate (b9Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							b9 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 0) {
					if (g0 > 0) {
						if (t == 0) {
							Instantiate (g0Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g0 -= 1;
						}
						if (t == 1) {
							Instantiate (g0Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g0 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 1) {
					if (g1 > 0) {
						if (t == 0) {
							Instantiate (g1Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g1 -= 1;
						}
						if (t == 1) {
							Instantiate (g1Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g1 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 2) {
					if (g2 > 0) {
						if (t == 0) {
							Instantiate (g2Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g2 -= 1;
						}
						if (t == 1) {
							Instantiate (g2Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g2 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 3) {
					if (g3 > 0) {
						if (t == 0) {
							Instantiate (g3Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g3 -= 1;
						}
						if (t == 1) {
							Instantiate (g3Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g3 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 4) {
					if (g4 > 0) {
						if (t == 0) {
							Instantiate (g4Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g4 -= 1;
						}
						if (t == 1) {
							Instantiate (g4Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g4 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 5) {
					if (g5 > 0) {
						if (t == 0) {
							Instantiate (g5Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g5 -= 1;
						}
						if (t == 1) {
							Instantiate (g5Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g5 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 6) {
					if (g6 > 0) {
						if (t == 0) {
							Instantiate (g6Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g6 -= 1;
						}
						if (t == 1) {
							Instantiate (g6Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g6 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 7) {
					if (g7 > 0) {
						if (t == 0) {
							Instantiate (g7Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g7 -= 1;
						}
						if (t == 1) {
							Instantiate (g7Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g7 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 8) {
					if (g8 > 0) {
						if (t == 0) {
							Instantiate (g8Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g8 -= 1;
						}
						if (t == 1) {
							Instantiate (g8Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g8 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 2 && number == 9) {
					if (g9 > 0) {
						if (t == 0) {
							Instantiate (g9Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							g9 -= 1;
						}
						if (t == 1) {
							Instantiate (g9Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							g9 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 0) {
					if (r0 > 0) {
						if (t == 0) {
							Instantiate (r0Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r0 -= 1;
						}
						if (t == 1) {
							Instantiate (r0Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r0 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 1) {
					if (r1 > 0) {
						if (t == 0) {
							Instantiate (r1Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r1 -= 1;
						}
						if (t == 1) {
							Instantiate (r1Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r1 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 2) {
					if (r2 > 0) {
						if (t == 0) {
							Instantiate (r2Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r2 -= 1;
						}
						if (t == 1) {
							Instantiate (r2Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r2 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 3) {
					if (r3 > 0) {
						if (t == 0) {
							Instantiate (r3Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r3 -= 1;
						}
						if (t == 1) {
							Instantiate (r3Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r3 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 4) {
					if (r4 > 0) {
						if (t == 0) {
							Instantiate (r4Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r4 -= 1;
						}
						if (t == 1) {
							Instantiate (r4Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r4 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 5) {
					if (r5 > 0) {
						if (t == 0) {
							Instantiate (r5Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r5 -= 1;
						}
						if (t == 1) {
							Instantiate (r5Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r5 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 6) {
					if (r6 > 0) {
						if (t == 0) {
							Instantiate (r6Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r6 -= 1;
						}
						if (t == 1) {
							Instantiate (r6Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r6 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 7) {
					if (r7 > 0) {
						if (t == 0) {
							Instantiate (r7Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r7 -= 1;
						}
						if (t == 1) {
							Instantiate (r7Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r7 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 8) {
					if (r8 > 0) {
						if (t == 0) {
							Instantiate (r8Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r8 -= 1;
						}
						if (t == 1) {
							Instantiate (r8Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r8 -= 1;
						}
					} else {
						i -= 1;
					}
				}
				if (color == 3 && number == 9) {
					if (r9 > 0) {
						if (t == 0) {
							Instantiate (r9Prefab, new Vector3 (X, Y, Z), Quaternion.identity); 
							r9 -= 1;
						}
						if (t == 1) {
							Instantiate (r9Prefab, new Vector3 (X2, Y2, Z2), Quaternion.identity); 
							r9 -= 1;
						}
					} else {
						i -= 1;
					}
				}

				if (t == 0) { 
				   X += 30;
				   i += 1;
				}
				if (t == 1) {
				   X2 += 30;
				   i += 1;
				}
			
			}

			p += 1;

			if (p == 1) {
				t += 1;
				i = 0;
			    X2 = 410;
			    Y2 = 540;
			    Z2 = 13;
			}
			if (p == 2) {
				t -= 1;
				i -= 1;
				X = 500;
				Y = 420;
				Z = 13;
			}
			if (p == 3 && q == 0) {
				X = 620;
				Y = 300;
				Z = 13;
				q += 1;
			}
		}//while
	}//Deal



	public void DRAW(){
		i -= 1;
		p -= 1;
	}



	public void CHANGE(){
		if (t == 0) {
			t += 1;
		} 
		else if(t == 1) {
			t -= 1;
		}
	}




}//class