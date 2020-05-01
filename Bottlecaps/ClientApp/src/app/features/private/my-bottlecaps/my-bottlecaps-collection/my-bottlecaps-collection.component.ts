import { Component, OnInit } from '@angular/core';
import { BottlecapService } from '../bottlecap.service';
import { Bottlecap, Tag, Link } from '../../../../shared/models';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-bottlecaps-collection',
  templateUrl: './my-bottlecaps-collection.component.html',
  styleUrls: ['./my-bottlecaps-collection.component.css']
})
export class MyBottlecapsCollectionComponent implements OnInit {

	constructor(private bottlecapService: BottlecapService,
		          private router: Router,	) { }
  //TODO: FIGURE OUT WHY TAGS/LINKS ARE DUPLICATED WHEN NEW BOTTLECAP IS ADDED
	ngOnInit() {
		this.bottlecapService.getBottlecaps(1); // TODO: FIX THIS ENDPOINT TO TAKE A PARAMETER FOR ProfileId
	}

	editBottlecap(bottlecapToEdit: Bottlecap) {
		//this.router.navigate(['edit-my-bottlecaps']);
		console.log("editBottlecap");
	}
	deleteBottlecap(bottlecapToDelete: Bottlecap) {
		console.log("deleteBottlecap: ", bottlecapToDelete);
		this.bottlecapService.deleteBottlecap(bottlecapToDelete);
	}
	checkCollection() {
		console.log("check Collection this.bottlecapService.bottleCapCollection: ", this.bottlecapService.bottleCapCollection);
		console.log("check Collection this.bottlecapService.emptyCaps: ", this.bottlecapService.emptyCaps);
	}
}
