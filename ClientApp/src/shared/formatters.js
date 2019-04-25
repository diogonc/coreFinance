export const formatMoney = value => {
  return parseFloat(value).toFixed(2);
};

export const formatDate = value => {
  return new Date(value).toLocaleDateString('en-US', {
    hour: '2-digit',
    minute: '2-digit'
  });
};
