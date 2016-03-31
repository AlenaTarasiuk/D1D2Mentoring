db.books.insert([
	{
		name: "Hobbit",
		author: "Tolkien",
		count: 5,
		genre: ["fantasy"],
		year: 2014
	},
	{
		name: "Lord of the rings",
		author: "Tolkien",
		count: 3,
		genre: ["fantasy"],
		year: 2015
	},
	{
		name: "Kolobok",
		count: 10,
		genre: ["kids"],
		year: 2000
	},
	{
		name: "Repka",
		count: 11,
		genre: ["kids"],
		year: 2000
	},
	{
		name: "Dyadya Stiopa",
		author: "Mihakov",
		count: 1,
		genre: ["kids"],
		year: 2001
	}
]);

db.books.find({count: {$gt: 1}}, {name: 1, id: 0}).sort({name: 1}).limit(3);
db.books.find({count: {$gt: 1}}, {name: 1, id: 0}).sort({name: 1}).limit(3).count();

db.books.find({}, {name: 1, count: 1, id: 0}).sort({count: 1}).limit(1);
db.books.find({}, {name: 1, count: 1, id: 0}).sort({count: -1}).limit(1);

db.books.distinct("author");

db.books.find({author: {$exists: false}}, {name: 1, id: 0});

db.books.update({}, {$inc: {count: 1}}, {multi: true, upsert: true});

db.books.update({$and: [{genre: "fantasy"}, {genre: {$ne: "favority"}}]}, {$push: {genre: "favority"}}, {multi: true});

db.books.remove({count: {$lt: 3}});

db.books.remove({});