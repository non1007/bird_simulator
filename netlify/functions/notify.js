const fetch = require('node-fetch');

exports.handler = async function(event, context) {
    const ACCESS_TOKEN = process.env.LINE_ACCESS_TOKEN;
    const message = event.queryStringParameters.message || 'Default notification message';

    const response = await fetch('https://notify-api.line.me/api/notify', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': `Bearer ${ACCESS_TOKEN}`
        },
        body: new URLSearchParams({ message })
    });

    if (response.ok) {
        return {
            statusCode: 200,
            body: JSON.stringify({ message: 'Notification sent successfully!' })
        };
    } else {
        const errorData = await response.json();
        return {
            statusCode: response.status,
            body: JSON.stringify({ error: errorData })
        };
    }
};