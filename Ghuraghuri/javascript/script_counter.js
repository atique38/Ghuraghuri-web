/*document.addEventListener("DOMContentLoaded", () => {
    function counter(id, start, end, duration) {
        let obj = document.getElementById(id),
            current = start,
            range = end - start,
            increment = end > start ? 1 : -1,
            step = Math.abs(Math.floor(duration / range)),
            timer = setInterval(() => {
                current += increment;
                obj.textContent = current;
                if (current == end) {
                    clearInterval(timer);
                }
            }, step);
    }
    //counter("count1", 0, 400, 3000);
    //counter("count2", 100, 50, 2500);
    //counter("count3", 0, 40, 3000);
});*/

function counter(id, end, duration, inc) {
    let obj = document.getElementById(id),
    
        current = 0,
        range = end - 0,
        increment = inc,
        step = Math.abs(Math.floor(duration / range)),
        timer = setInterval(() => {

            if (current > end) {
                obj.textContent = end;
                clearInterval(timer);
            }
            else {
                obj.textContent = current;
            }
            
            if (current == end) {
                clearInterval(timer);
            }
            current += increment;
        }, step);
    
        
}

