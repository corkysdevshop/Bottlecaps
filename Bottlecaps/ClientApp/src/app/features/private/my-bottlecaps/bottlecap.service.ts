import { Injectable } from '@angular/core';
import { Bottlecap, Tag, Link } from './../../../shared/models';
import { Subject } from 'rxjs';
import { DataService } from '../../../shared/data.service';

@Injectable({
  providedIn: 'root'
})
export class BottlecapService {
	bottlecapsChanged = new Subject<Bottlecap[]>();
	bottleCapCollection: Bottlecap[] = [];
	emptyCaps: Bottlecap[] = [];

	constructor(private dataService: DataService) {
		this.bottlecapsChanged.subscribe(newCaps => {
			this.bottleCapCollection = [];
			this.emptyCaps = [];
			this.emptyCaps = newCaps.slice();
			this.fillBottlecaps();
		});
		this.getBottlecaps(1); //TODO: REPLACE PROFILE ID HERE
	}

	fillBottlecaps() {
		for (const bottlecap of this.emptyCaps) {
			this.fillTags(bottlecap);
			this.fillLinks(bottlecap);
			this.bottleCapCollection.push(bottlecap);
		}
	}

	fillTags(bottlecap: Bottlecap) {
		this.dataService.getBottlecapTags(bottlecap.bottlecapId).subscribe(tags => {
			bottlecap.tag = [];
			for (const tag of tags) {
				bottlecap.tag.push(new Tag(tag.tagText));
			}
		},
			err => { console.error(err) }
		)
	}

	fillLinks(bottlecap: Bottlecap) {
		this.dataService.getBottlecapLinks(bottlecap.bottlecapId).subscribe(links => {
			bottlecap.link = [];
			for (const link of links) {
				bottlecap.link.push(new Link(link.linkText));
			}
		},
			err => { console.error(err) }
		);
	}

  /**
    * CREATE
    */
	addBottlecapToCollection(bottlecap: Bottlecap) {
		this.dataService.addBottlecap(bottlecap).subscribe(response => {
			console.log("add bottlecap service response: ",response);
			this.bottleCapCollection.push(response);
			this.bottlecapsChanged.next(this.bottleCapCollection.slice());
		}, err => {
				console.error(err);
		});
	}
  /**
    * READ
    */

	getBottlecaps(ProfileId: number) {
		this.dataService.getMyCollection(ProfileId).subscribe(initialEmptyBottlecaps => {
			this.bottleCapCollection = [];
			this.bottleCapCollection = initialEmptyBottlecaps.slice()
			this.bottlecapsChanged.next(this.bottleCapCollection.slice());
		});
	}

  /**
  * UPDATE (PUT)
  */
      //TODO: IMPLEMENT 
  /**
    * DELETE (DELETE)
    */
	deleteBottlecap(bottlecap: Bottlecap) {
		this.dataService.deleteBottlecap(bottlecap).subscribe(result => {
			console.log('success: ', result);
			//var x = this.bottleCapCollection.find(bc => bc.bottlecapId === result.bottlecapId);
			var removeIndex = this.bottleCapCollection.map(function (bc) { return bc.bottlecapId }).indexOf(result.bottlecapId);
			this.bottleCapCollection.splice(removeIndex, 1);
			this.bottlecapsChanged.next(this.bottleCapCollection.slice());
		});
	}
}

