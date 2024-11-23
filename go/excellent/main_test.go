package main

import "testing"

func TestEvenOrOdd(t *testing.T) {
	result := EvenOrOdd(10)
	if result != "even" {
		t.Errorf("expected: even, actual: %s", result)
	}

	result2 := EvenOrOdd(11)
	if (result2 != "odd"){
		t.Errorf("expected: odd, actual: %s", result2)
	}
}
