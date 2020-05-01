import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-snack',
  templateUrl: './snack.component.html',
  styleUrls: ['./snack.component.css']
})
export class SnackComponent {

  constructor(private _snackBar: MatSnackBar) { }

	openSnackBar(message: string, action: string) {
		console.log('in snack component');
		this._snackBar.open(message, action, { duration: 2000 });
	}

}
