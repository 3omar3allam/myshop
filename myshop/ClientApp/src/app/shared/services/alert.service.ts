import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";

@Injectable({
    providedIn:'root',
})
export class AlertService {
    constructor(private snack: MatSnackBar) {}

    success(message: string, action = "OK") {
        return this.snack.open(message, action, {
            horizontalPosition: "end",
        });
    }

    fail(message: string, action = "OK") {
        return this.snack.open(message, action, {
            panelClass: ['bg-danger'],
            horizontalPosition: "end",
        });
    }
}