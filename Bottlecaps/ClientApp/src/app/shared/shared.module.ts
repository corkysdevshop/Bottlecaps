import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SnackComponent } from './snack/snack.component';
import { MaterialModule } from './material/material.module';


@NgModule({
	declarations: [
		FetchDataComponent,
		SnackComponent
	],
  imports: [
	  CommonModule,
	  MaterialModule
	],
	exports: [
    SnackComponent
	]
})
export class SharedModule { }
