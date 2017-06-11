db.getCollection('category').updateMany(
   { "categoryType": "credit"}  ,
   {
     $set: { "categoryType": 1},
     $currentDate: { lastModified: true }
   }
)
   
db.getCollection('category').updateMany(
   { "categoryType": "debit"}  ,
   {
     $set: { "categoryType": 2},
     $currentDate: { lastModified: true }
   }
)
   
db.getCollection('category').updateMany(
   { "categoryType": "creditTransfer"}  ,
   {
     $set: { "categoryType": 3},
     $currentDate: { lastModified: true }
   }
)
   
db.getCollection('category').updateMany(
   { "categoryType": "debitTransfer"}  ,
   {
     $set: { "categoryType": 4},
     $currentDate: { lastModified: true }
   }
)