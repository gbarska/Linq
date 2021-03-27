Operators:

Intro
imediate operators: Count(), ToArray() -> traverses the entire collection to perform task imediately after the metod is called;

deferred operators: Select() -> happens to the collection when you call theese operators
nothing will happened imediatelly. Instead when you call any imediate on the collection,then the calculation is made.

deferred could be :
streaming: do not need to real all data before elements are yielded
non-streaming: need to real all data before elements are yielded
