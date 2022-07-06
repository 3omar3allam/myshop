import { FormGroup } from "@angular/forms";

export const mustMatch = (controlId: string, otherControlId: string) => {
    return (formGroup: FormGroup) => {
        const value1 = formGroup.get(controlId)?.value;
        const value2 = formGroup.get(otherControlId)?.value;

        return value1 === value2 ? null : {mustMatch: true};
    }
}